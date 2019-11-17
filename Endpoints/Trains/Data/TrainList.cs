using irish_railways_api.Common.Xml;
using irish_railways_api.Controllers.Trains.Models;
using System.Xml.Serialization;

namespace irish_railways_api.Trains.Data {
	[XmlRoot("ArrayOfObjTrainPositions", Namespace = "http://api.irishrail.ie/realtime/")]
	public class TrainMovementList : IXmlNode<Train> {
		[XmlElement("objTrainPositions")]
		public Train[] Items { get; set; }
	}
}
