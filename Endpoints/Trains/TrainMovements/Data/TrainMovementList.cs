using irish_railways_api.Common.Xml;
using irish_railways_api.Endpoints.Trains.TrainMovements.Models;
using System.Xml.Serialization;

namespace irish_railways_api.Trains.TrainMovements.Data {
	[XmlRoot("ArrayOfObjTrainMovements ", Namespace = "http://api.irishrail.ie/realtime/")]
	public class TrainMovementList : IXmlNode<TrainMovement> {
		[XmlElement("objTrainMovements")]
		public TrainMovement[] Items { get; set; }
	}
}
