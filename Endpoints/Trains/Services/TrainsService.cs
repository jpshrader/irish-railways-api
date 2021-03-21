using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.Trains.Adapters;
using irish_railways_api.Trains.Data;
using System;
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

		public ResourceList<TrainResource> GetTrains(string apiVersion) {
			return new ResourceList<TrainResource> {
				Resources = GetTrainResources(trainsRetriever.GetTrains(), apiVersion),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE, HateoasLink.SELF, apiVersion)
				}
			};
		}

		public TrainResource GetTrain(string trainCode, string apiVersion) {
			var train = trainsRetriever.GetTrains().FirstOrDefault(t => t.TrainCode.Equals(trainCode, StringComparison.OrdinalIgnoreCase));

			if (train == null)
				return null;

			return trainAdapter.Adapt(train, apiVersion);
		}

		private IEnumerable<TrainResource> GetTrainResources(IEnumerable<Train> trains, string apiVersion) {
			if (trains == null)
				return null;

			return trains.Select(t => trainAdapter.Adapt(t, apiVersion)).OrderBy(t => t.Origin);
		}
	}
}
