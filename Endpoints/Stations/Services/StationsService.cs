using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.Data;
using irish_railways_api.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Stations.Services {
	public class StationsService : IStationsService {
		private readonly IStationRetriever stationRetriever;

		public StationsService(IStationRetriever stationRetriever) {
			this.stationRetriever = stationRetriever;
		}

		public StationResource GetStations() {
			return GetStationResource(stationRetriever.GetStations());
		}

		public static StationResource GetStationResource(IEnumerable<Station> stations) {
			return new StationResource {
				Resources = stations,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationsController.ROUTE, HateoasLink.GET_SELF)
				}
			};
		}
	}
}
