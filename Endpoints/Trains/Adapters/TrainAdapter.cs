using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Controllers.Trains.Models;

namespace irish_railways_api.Endpoints.Trains.Adapters {
	public class TrainAdapter : ITrainAdapter {
		private const string API_NEWLINE = "\\n";

		public TrainResource Adapt(Train train) {
			return new TrainResource {
				Code = train.TrainCode,
				Status = GetTrainStatus(train.TrainStatus),
				Direction = train.Direction.Replace("To", "Towards"),
				Date = train.TrainDate,
				Latitude = train.TrainLatitude,
				Longitude = train.TrainLongitude,
				Origin = GetOriginStationFromMessage(train.PublicMessage),
				Destination = GetDestinationFromMessage(train.PublicMessage),
				Message = GetContextFromMessage(train.PublicMessage),
				MinutesLate = GetTimeDeltaFromMessage(train.PublicMessage),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(TrainsController.ROUTE_SINGLE, HateoasLink.SELF, routeArgs: train.TrainCode)
				}
			};
		}

		private static string GetOriginStationFromMessage(string publicMessage) {
			var origin = publicMessage.Split(API_NEWLINE)[1];
			origin = origin.Substring(origin.IndexOf("-") + 1);

			return origin.Substring(0, origin.IndexOf("to ")).Trim();
		}

		private static string GetDestinationFromMessage(string publicMessage) {
			var destination = publicMessage.Split(API_NEWLINE)[1];
			destination = destination.Substring(destination.LastIndexOf("to ") + 3);

			if (destination.Contains('('))
				destination = destination.Substring(0, destination.IndexOf('('));

			return destination.Trim();
		}

		private static int GetTimeDeltaFromMessage(string publicMessage) {
			var destination = publicMessage.Split(API_NEWLINE)[1];

			if (!destination.Contains('('))
				return 0;

			var startOfLateMessage = destination.IndexOf('(') + 1;
			destination = destination.Substring(startOfLateMessage, destination.IndexOf("min") - startOfLateMessage);

			var isInt = int.TryParse(destination.Trim(), out var delta);
			return isInt ? delta : 0;
		}

		private static string GetContextFromMessage(string publicMessage) {
			return publicMessage.Substring(publicMessage.LastIndexOf(API_NEWLINE) + API_NEWLINE.Length).Trim();
		}

		private static string GetTrainStatus(string status) {
			if (status == "R") {
				return "Running";
			} else if (status == "N") {
				return "Stopped";
			} else if (status == "T") {
				return "Terminated";
			} else {
				return status;
			}
		}
	}
}
