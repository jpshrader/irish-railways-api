﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.TrainMovements.Models;

namespace irish_railways_api.Endpoints.TrainMovements.Services {
	public interface ITrainMovementService {
		ResourceList<TrainMovementResource> GetTrainMovements(string trainCode, string apiVersion);
	}
}
