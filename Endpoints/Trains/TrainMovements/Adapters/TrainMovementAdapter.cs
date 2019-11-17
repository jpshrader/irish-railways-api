using irish_railways_api.Endpoints.Trains.TrainMovements.Models;

namespace irish_railways_api.Endpoints.Trains.TrainMovements.Adapters {
	public class TrainMovementAdapter : ITrainMovementAdapter {
		public TrainMovementResource Adapt(TrainMovement trainMovement) {
			return new TrainMovementResource {
				TrainCode = trainMovement.TrainCode,
			};
		}
	}
}
