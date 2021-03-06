﻿using irish_railways_api.Common;
using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains;
using irish_railways_api.Endpoints.TrainMovements.Models;
using irish_railways_api.Endpoints.TrainMovements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Endpoints.TrainMovements {
	[ApiController]
	[ApiVersion1]
	public class TrainMovementsController : ControllerBase {
		public const string ROUTE = TrainsController.ROUTE_SINGLE + "/movements";

		private readonly ITrainMovementService trainMovementService;

		public TrainMovementsController(ITrainMovementService trainMovementService) {
			this.trainMovementService = trainMovementService;
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<TrainMovementResource>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE)]
		public IActionResult GetTrainMovements(string trainCode) {
			var result = trainMovementService.GetTrainMovements(trainCode, ApiVersion1.VERSION);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
