using irish_railways_api.Common.Access;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.Trains.Services;
using irish_railways_api.Trains.Data;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Trains {
	[ApiController]
	public class TrainsController : ControllerBase {
		public const string ROUTE = "api/trains";
		private readonly TrainsService trainsService = new TrainsService(new TrainsRetriever(new ApiAccess<Train>()));

		[HttpGet(ROUTE)]
		public IActionResult GetTrains() {
			var result = trainsService.GetTrains();

			return Ok(result);
		}
	}
}
