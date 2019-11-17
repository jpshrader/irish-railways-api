using irish_railways_api.Endpoints.Trains.TrainMovements.Models;

namespace irish_railways_api.Endpoints.Trains.TrainMovements.Adapters {
	public class TrainMovementAdapter : ITrainMovementAdapter {
		public TrainMovementResource Adapt(TrainMovement trainMovement) {
			return new TrainMovementResource {
				TrainCode = trainMovement.TrainCode.Trim(),
				TrainDate = trainMovement.TrainDate,
				LocationCode = trainMovement.LocationCode,
				LocationFullName = trainMovement.LocationFullName,
				LocationOrder = trainMovement.LocationOrder,
				LocationType = trainMovement.LocationType,
				TrainOrigin = trainMovement.TrainOrigin,
				TrainDestination = trainMovement.TrainDestination,
				ScheduledArrival = trainMovement.ScheduledArrival,
				ScheduledDeparture = trainMovement.ScheduledDeparture,
				ExpectedArrival = trainMovement.ExpectedArrival,
				ExpectedDeparture = trainMovement.ExpectedDeparture,
				Arrival = trainMovement.Arrival,
				Departure = trainMovement.Departure,
				AutoArrival = trainMovement.AutoArrival,
				AutoDepart = trainMovement.AutoDepart,
				StopType = trainMovement.StopType
			};
		}
	}
}
