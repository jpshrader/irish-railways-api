using irish_railways_api.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Stations.Data {
	public interface IStationRetriever {
		IEnumerable<Station> GetStations();
	}
}
