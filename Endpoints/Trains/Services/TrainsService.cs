using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Trains.Data;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Trains.Services {
	public class TrainsService : ITrainsService {
		private readonly ITrainsRetriever trainsRetriever;

		public TrainsService(ITrainsRetriever trainsRetriever) {
			this.trainsRetriever = trainsRetriever;
		}

		public TrainsResource GetTrains() {
			return GetStationResource(trainsRetriever.GetTrains());
		}

		public static TrainsResource GetStationResource(IEnumerable<Train> stations) {
			return new TrainsResource {
				Resources = stations,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE, HateoasLink.GET_SELF)
				}
			};
		}
	}
}
