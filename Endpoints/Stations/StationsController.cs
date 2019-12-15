using irish_railways_api.Common.Resources;
using irish_railways_api.Endpoints.Stations.Models;
using irish_railways_api.Endpoints.Stations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Stations {
	[ApiController]
	public class StationsController : ControllerBase {
		public const string ROUTE = "/api/stations";
		public const string ROUTE_SINGLE = ROUTE + "/{stationName}";

		private readonly StationsService stationsService = new StationsService();

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<StationResource>))]
		[HttpGet(ROUTE)]
		public IActionResult GetStations() {
			var result = stationsService.GetStations();

			return Ok(result);
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StationResource))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE_SINGLE)]
		public IActionResult GetStations(string stationName) {
			var result = stationsService.GetStation(stationName);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}