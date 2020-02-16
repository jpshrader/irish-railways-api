using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.TrainMovements.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Trains.Adapters {
	public interface ITrainAdapter {
		TrainResource Adapt(Train train, IEnumerable<TrainMovement> trainMovements);
	}
}
