using irish_railways_api.Endpoints.TrainMovements.Models;

namespace irish_railways_api.Endpoints.TrainMovements.Adapters {
	public interface ITrainMovementAdapter {
		TrainMovementResource Adapt(TrainMovement trainMovement);
	}
}
