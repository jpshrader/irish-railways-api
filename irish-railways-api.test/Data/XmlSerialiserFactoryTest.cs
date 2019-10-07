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
    }
}
