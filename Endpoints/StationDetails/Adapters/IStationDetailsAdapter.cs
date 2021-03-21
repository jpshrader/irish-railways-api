using irish_railways_api.Endpoints.StationDetails.Models;

namespace irish_railways_api.Endpoints.StationDetails.Adapters {
	public interface IStationDetailsAdapter {
		StationDetailsResource Adapt(StationDetail stationDetails);
	}
}
