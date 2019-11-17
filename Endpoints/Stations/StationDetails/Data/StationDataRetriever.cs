using irish_railways_api.Common.Access;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Data {
	public class StationDataRetriever : IStationDataRetriever {
		private const string GET_STATION_DATA = "http://api.irishrail.ie/realtime/realtime.asmx/getStationDataByNameXML?StationDesc=";

		private readonly IApiAccess<StationData> apiAccess;

		public StationDataRetriever(IApiAccess<StationData> apiAccess) {
			this.apiAccess = apiAccess;
		}

		public IEnumerable<StationData> GetStationData(string stationId) {
			return apiAccess.GetResources(new Uri(GET_STATION_DATA + stationId)).Result;
		}
	}
}
