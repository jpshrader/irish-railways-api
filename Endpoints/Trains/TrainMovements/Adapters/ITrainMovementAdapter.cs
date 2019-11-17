using irish_railways_api.Endpoints.Trains.TrainMovements.Models;

namespace irish_railways_api.Endpoints.Trains.TrainMovements.Adapters {
	public interface ITrainMovementAdapter {
		TrainMovementResource Adapt(TrainMovement trainMovement);
	}
}
