﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains.Models;

namespace irish_railways_api.Endpoints.Trains.Services {
	public interface ITrainsService {
		ResourceList<TrainResource> GetTrains(string apiVersion);

		TrainResource GetTrain(string trainCode, string apiVersion);
	}
}
