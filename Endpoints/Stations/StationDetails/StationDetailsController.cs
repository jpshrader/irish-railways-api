using irish_railways_api.Common.Access;
using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.StationDetails.Adapters;
using irish_railways_api.Endpoints.Stations.StationDetails.Data;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;
using irish_railways_api.Endpoints.Stations.StationDetails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Endpoints.Stations.StationDetails {
	[ApiController]
	public class StationDetailsController : ControllerBase {
		public const string ROUTE = StationsController.ROUTE_SINGLE + "/details";

		private readonly IStationDetailsService stationDetailsService = new StationDetailsService(new StationDataRetriever(new ApiAccess<StationData>()), new StationDetailsAdapter());

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<StationDetailsResource>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE)]
		public IActionResult GetDetails(string stationName) {
			var result = stationDetailsService.GetStationDetails(stationName);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
