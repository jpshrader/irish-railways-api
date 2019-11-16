using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.Stations.Models;

namespace irish_railways_api.Endpoints.Stations.Services {
	public interface IStationsService {
		ResourceList<StationResource> GetStations();

		StationResource GetStation(string stationId);
	}
}
