using irish_railways_api.Endpoints.Stations.StationDetails.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Data {
	public interface IStationDataRetriever {
		IEnumerable<StationData> GetStationData(string stationId);
	}
}
