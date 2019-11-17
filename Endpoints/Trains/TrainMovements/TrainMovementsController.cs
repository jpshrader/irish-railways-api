using irish_railways_api.Common.Access;
using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Endpoints.Trains.TrainMovements.Adapters;
using irish_railways_api.Endpoints.Trains.TrainMovements.Data;
using irish_railways_api.Endpoints.Trains.TrainMovements.Models;
using irish_railways_api.Endpoints.Trains.TrainMovements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Endpoints.Trains.TrainMovements {
	public class TrainMovementsController : ControllerBase {
		public const string ROUTE = TrainsController.ROUTE_SINGLE + "/movements";

		private readonly ITrainMovementService movementService = new TrainMovementService(new TrainMovementRetriever(new ApiAccess<TrainMovement>()), new TrainMovementAdapter());

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<TrainMovementResource>))]
		[HttpGet(ROUTE)]
		public IActionResult GetTrainMovements(string trainCode) {
			var result = movementService.GetTrainMovements(trainCode);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
