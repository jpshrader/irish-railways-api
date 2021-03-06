﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Endpoints.TrainMovements.Adapters;
using irish_railways_api.Endpoints.TrainMovements.Data;
using irish_railways_api.Endpoints.TrainMovements.Models;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.TrainMovements.Services {
	public class TrainMovementService : ITrainMovementService {
		private readonly ITrainMovementRetriever movementRetriever;
		private readonly ITrainMovementAdapter trainMovementAdapter;

		public TrainMovementService(ITrainMovementRetriever movementRetriever, ITrainMovementAdapter trainMovementAdapter) {
			this.movementRetriever = movementRetriever;
			this.trainMovementAdapter = trainMovementAdapter;
		}

		public ResourceList<TrainMovementResource> GetTrainMovements(string trainCode, string apiVersion) {
			return new ResourceList<TrainMovementResource> {
				Resources = GetTrainMovementResources(movementRetriever.GetTrainMovements(trainCode)),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainMovementsController.ROUTE, HateoasLink.SELF, apiVersion, trainCode),
					HateoasLink.BuildGetLink(TrainsController.ROUTE_SINGLE, "train", apiVersion, trainCode)
				}
			};
		}

		private IEnumerable<TrainMovementResource> GetTrainMovementResources(IEnumerable<TrainMovement> movements) {
			if (movements == null)
				return Enumerable.Empty<TrainMovementResource>();

			return movements.Select(trainMovementAdapter.Adapt);
		}
	}
}
