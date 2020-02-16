using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.TrainMovements.Data;
using irish_railways_api.Endpoints.Trains.Adapters;
using irish_railways_api.Trains.Data;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.Trains.Services {
	public class TrainsService : ITrainsService {
		private readonly ITrainsRetriever trainsRetriever;
		private readonly ITrainMovementRetriever trainMovementRetriever;
		private readonly ITrainAdapter trainAdapter;

		public TrainsService() : this(new TrainsRetriever(), new TrainMovementRetriever(), new TrainAdapter()) { }

		public TrainsService(ITrainsRetriever trainsRetriever, ITrainMovementRetriever trainMovementRetriever, ITrainAdapter trainAdapter) {
			this.trainsRetriever = trainsRetriever;
			this.trainMovementRetriever = trainMovementRetriever;
			this.trainAdapter = trainAdapter;
		}

		public ResourceList<TrainResource> GetTrains() {
			return new ResourceList<TrainResource> {
				Resources = GetTrainResources(trainsRetriever.GetTrains()),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE, HateoasLink.SELF)
				}
			};
		}

		public TrainResource GetTrain(string trainCode) {
			var train = trainsRetriever.GetTrains().FirstOrDefault(t => t.TrainCode == trainCode);

			if (train == null)
				return null;

			var trainMovements = trainMovementRetriever.GetTrainMovements(train.TrainCode);
			return trainAdapter.Adapt(train, trainMovements);
		}

		private IEnumerable<TrainResource> GetTrainResources(IEnumerable<Train> trains) {
			if (trains == null)
				yield break;

			foreach (var train in trains) {
				var trainMovements = trainMovementRetriever.GetTrainMovements(train.TrainCode);

				yield return trainAdapter.Adapt(train, trainMovements);
			}
		}
	}
}
