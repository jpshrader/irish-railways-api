using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.Trains.TrainMovements.Models;

namespace irish_railways_api.Endpoints.Trains.TrainMovements.Services {
	public interface ITrainMovementService {
		ResourceList<TrainMovementResource> GetTrainMovements(string trainCode);
	}
}
