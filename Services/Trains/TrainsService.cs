using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Data.Trains;
using irish_railways_api.Models.Common;
using System.Collections.Generic;

namespace irish_railways_api.Services.Trains {
    public class TrainsService : ITrainsService {
        private readonly ITrainsRetriever trainsRetriever;

        public TrainsService(ITrainsRetriever trainsRetriever) {
            this.trainsRetriever = trainsRetriever;
        }

        public TrainsResource GetTrains() {
            return GetStationResource(trainsRetriever.GetTrains());
        }

        public TrainsResource GetStationResource(IEnumerable<Train> stations) {
            return new TrainsResource {
                Resources = stations,
                Links = new HateoasLink[] {
                    HateoasLink.BuildGetLink(TrainsController.ROUTE, HateoasLink.GET_SELF)
                }
            };
        }
    }
}
