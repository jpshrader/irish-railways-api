using irish_railways_api.Controllers.Stations;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Endpoints.Stations.StationDetails {
	[ApiController]
	public class StationDetailsController : ControllerBase {
		public const string ROUTE = StationsController.ROUTE_SINGLE + "/details";

	}
}
