using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.Trains.Adapters;
using irish_railways_api.Trains.Data;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.Trains.Services {
	public class TrainsService : ITrainsService {
		private readonly ITrainsRetriever trainsRetriever;
		private readonly ITrainAdapter trainAdapter;

		public TrainsService(ITrainsRetriever trainsRetriever, ITrainAdapter trainAdapter) {
			this.trainsRetriever = trainsRetriever;
			this.trainAdapter = trainAdapter;
		}

		public ResourceList<TrainResource> GetTrains() {
			return new ResourceList<TrainResource> {
				Resources = GetTrainResources(trainsRetriever.GetTrains()),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE, HateoasLink.GET_SELF)
				}
			};
		}

		public TrainResource GetTrain(string trainCode) {
			var train = trainsRetriever.GetTrains().SingleOrDefault(t => t.TrainCode == trainCode);

			if (train == null)
				return null;

			return trainAdapter.Adapt(train);
		}

		private IEnumerable<TrainResource> GetTrainResources(IEnumerable<Train> trains) {
			if (trains == null)
				return Enumerable.Empty<TrainResource>();

			return trains.Select(trainAdapter.Adapt);
		}
	}
}
