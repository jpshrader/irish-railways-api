using irish_railways_api.Endpoints.Stations.Models;
using irish_railways_api.Models;

namespace irish_railways_api.Endpoints.Stations.Adapters {
	public interface IStationAdapter {
		StationResource Adapt(Station station);
	}
}
