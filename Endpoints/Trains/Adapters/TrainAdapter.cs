using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;

namespace irish_railways_api.Endpoints.Trains.Adapters {
	public class TrainAdapter : ITrainAdapter {
		public TrainResource Adapt(Train train) {
			return new TrainResource {
				Code = train.TrainCode,
				Status = train.TrainStatus,
				Direction = train.Direction,
				Date = train.TrainDate,
				PublicMessage = train.PublicMessage,
				Latitude = train.TrainLatitude,
				Longitude = train.TrainLongitude,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE_SINGLE, HateoasLink.SELF, routeArgs: train.TrainCode)
				}
			};
		}
	}
}
