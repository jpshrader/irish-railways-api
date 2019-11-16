using irish_railways_api.Common.Xml;
using irish_railways_api.Models;
using System.Xml.Serialization;

namespace irish_railways_api.Endpoints.Stations.Data {
	[XmlRoot("ArrayOfObjStation", Namespace = "http://api.irishrail.ie/realtime/")]
	public class StationList : IXmlNode<Station> {
		[XmlElement("objStation")]
		public Station[] Items { get; set; }
	}
}
