using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.StationDetails.Models;

namespace irish_railways_api.Endpoints.StationDetails.Services {
	public interface IStationDetailsService {
		ResourceList<StationDetailsResource> GetStationDetails(string stationName, string apiVersion);
	}
}
