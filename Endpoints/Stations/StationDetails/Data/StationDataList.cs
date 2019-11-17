using irish_railways_api.Common.Xml;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;
using System.Xml.Serialization;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Data {
	[XmlRoot("ArrayOfObjStationData", Namespace = "http://api.irishrail.ie/realtime/")]
	public class StationDataList : IXmlNode<StationData> {
		[XmlElement("objStationData")]
		public StationData[] Items { get; set; }
	}
}
