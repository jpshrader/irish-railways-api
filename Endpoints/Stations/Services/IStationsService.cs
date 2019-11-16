using irish_railways_api.Models;

namespace irish_railways_api.Endpoints.Stations.Services {
	public interface IStationsService {
		StationResource GetStations();
	}
}
