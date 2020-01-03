using irish_railways_api.Common.Access;
using irish_railways_api.Endpoints.TrainMovements.Models;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Endpoints.TrainMovements.Data {
	public class TrainMovementRetriever : ITrainMovementRetriever {
		public const string GET_MOVEMENT_URL = "http://api.irishrail.ie/realtime/realtime.asmx/getTrainMovementsXML?TrainId=";
		private readonly IApiAccess<TrainMovement> apiAccess;

		public TrainMovementRetriever() : this(new ApiAccess<TrainMovement>()) { }

		public TrainMovementRetriever(IApiAccess<TrainMovement> apiAccess) {
			this.apiAccess = apiAccess;
		}

		public IEnumerable<TrainMovement> GetTrainMovements(string trainCode) {
			var today = DateTime.UtcNow.ToString("dd-MM-yyyy");
			return apiAccess.GetResources(new Uri($"{GET_MOVEMENT_URL + trainCode}&TrainDate={today}"));
		}
	}
}
