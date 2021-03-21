using irish_railways_api.Controllers.Trains.Models;

namespace irish_railways_api.Endpoints.Trains.Adapters {
	public interface ITrainAdapter {
		TrainResource Adapt(Train train, string apiVersion);
	}
}
