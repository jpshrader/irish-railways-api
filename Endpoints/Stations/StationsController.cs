using irish_railways_api.Common.Access;
using irish_railways_api.Data.Stations;
using irish_railways_api.Endpoints.Stations.Adapters;
using irish_railways_api.Endpoints.Stations.Services;
using irish_railways_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Stations {
	[ApiController]
	public class StationsController : ControllerBase {
		public const string ROUTE = "api/stations";
		public const string ROUTE_SINGLE = ROUTE + "/{stationId}";

		private readonly StationsService stationsService = new StationsService(new StationRetriever(new ApiAccess<Station>()), new StationAdapter());

		[HttpGet(ROUTE)]
		public IActionResult GetStations() {
			var result = stationsService.GetStations();

			return Ok(result);
		}

		[HttpGet(ROUTE_SINGLE)]
		public IActionResult GetStations(string stationId) {
			var result = stationsService.GetStation(stationId);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}