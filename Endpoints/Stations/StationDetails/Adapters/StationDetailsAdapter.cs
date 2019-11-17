using irish_railways_api.Endpoints.Stations.StationDetails.Models;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Adapters {
	public class StationDetailsAdapter : IStationDetailsAdapter {
		public StationDetailsResource Adapt(StationData stationData) {
			return new StationDetailsResource {

			};
		}
	}
}
