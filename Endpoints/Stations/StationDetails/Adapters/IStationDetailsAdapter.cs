using irish_railways_api.Endpoints.Stations.StationDetails.Models;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Adapters {
	public interface IStationDetailsAdapter {
		StationDetailsResource Adapt(StationData stationData);
	}
}
