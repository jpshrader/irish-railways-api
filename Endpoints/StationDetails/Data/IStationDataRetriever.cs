using irish_railways_api.Endpoints.StationDetails.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.StationDetails.Data {
	public interface IStationDataRetriever {
		IEnumerable<StationData> GetStationData(string stationId);
	}
}
