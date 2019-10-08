using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Data;
using irish_railways_api.Models;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace irish_railways_api.test.Data {
    [TestFixture]
    public class XmlSerialiserFactoryTest {
        private readonly XmlSerialiserFactory subject = new XmlSerialiserFactory();

        [Test]
        public void XmlSerializerFactory_GetStationSerialiser_ReturnsStationList() {
            var stationsXml = @"<ArrayOfObjStation xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://api.irishrail.ie/realtime/"">
                                    <objStation>
                                        <StationDesc>Belfast</StationDesc>
                                        <StationAlias/>
                                        <StationLatitude>54.6123</StationLatitude>
                                        <StationLongitude>-5.91744</StationLongitude>
                                        <StationCode>BFSTC</StationCode>
                                        <StationId>228</StationId>
                                    </objStation>
                             </ArrayOfObjStation>";
            var serializer = subject.GetXmlSerialiser<Station>();

            var result = (IXmlNode<Station>)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(stationsXml)));
            var stationResult = result.Items[0];

            Assert.AreEqual(1, result.Items.Length);
            Assert.AreEqual("Belfast", stationResult.StationDesc);
        }

        [Test]
        public void XmlSerializerFactory_GetTrainSerialiser_ReturnsTrainList() {
            var trainsXml = @"<ArrayOfObjTrainPositions  xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://api.irishrail.ie/realtime/"">
                                    <objTrainPositions>
                                        <TrainStatus>N</TrainStatus>
                                        <TrainLatitude>51.8491</TrainLatitude>
                                        <TrainLongitude>-8.29956</TrainLongitude>
                                        <TrainCode>P230</TrainCode>
                                        <TrainDate>08 Oct 2019</TrainDate>
                                        <PublicMessage>P230\nCobh to Cork\nExpected Departure 06:00</PublicMessage>
                                        <Direction>To Cork</Direction>
                                    </objTrainPositions>
                             </ArrayOfObjTrainPositions >";
            var serializer = subject.GetXmlSerialiser<Train>();

            var result = (IXmlNode<Train>)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(trainsXml)));
            var trainList = result.Items[0];

            Assert.AreEqual(1, result.Items.Length);
            Assert.AreEqual("To Cork", trainList.Direction);
        }
    }
}
