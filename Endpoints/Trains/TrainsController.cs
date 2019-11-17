using irish_railways_api.Common.Access;
using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.Trains.Adapters;
using irish_railways_api.Endpoints.Trains.Services;
using irish_railways_api.Trains.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Trains {
	[ApiController]
	public class TrainsController : ControllerBase {
		public const string ROUTE = "/api/trains";
		public const string ROUTE_SINGLE = ROUTE + "/{trainCode}";
		private readonly TrainsService trainsService = new TrainsService(new TrainsRetriever(new ApiAccess<Train>()), new TrainAdapter());

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<TrainResource>))]
		[HttpGet(ROUTE)]
		public IActionResult GetTrains() {
			var result = trainsService.GetTrains();

			return Ok(result);
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainResource))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE_SINGLE)]
		public IActionResult GetTrain(string trainCode) {
			var result = trainsService.GetTrain(trainCode);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
