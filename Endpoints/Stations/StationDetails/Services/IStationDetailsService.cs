using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Services {
	public interface IStationDetailsService {
		ResourceList<StationDetailsResource> GetStationDetails(string stationId);
	}
}
