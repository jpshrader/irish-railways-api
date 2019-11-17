using irish_railways_api.Endpoints.Trains.TrainMovements.Models;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.Trains.TrainMovements.Data {
	public interface ITrainMovementRetriever {
		IEnumerable<TrainMovement> GetTrainMovements(string trainCode);
	}
}
