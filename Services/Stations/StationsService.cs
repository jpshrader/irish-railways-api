using irish_railways_api.Controllers.Stations;
using irish_railways_api.Data.Stations;
using irish_railways_api.Models;
using irish_railways_api.Models.Common;
using System.Collections.Generic;

namespace irish_railways_api.Services.Stations {
    public class StationsService {
        private readonly IStationRetriever stationRetriever;

        public StationsService(IStationRetriever stationRetriever) {
            this.stationRetriever = stationRetriever;
        }

        public StationResource GetStations() {
            return GetStationResource(stationRetriever.GetStations());
        }

        public StationResource GetStationResource(IEnumerable<Station> stations) {
            return new StationResource {
                Resources = stations,
                Links = new HateoasLink[] {
                    HateoasLink.BuildGetLink(StationsController.ROUTE, HateoasLink.GET_SELF)
                }
            };
        }
    }
}
