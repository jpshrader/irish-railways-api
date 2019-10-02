using irish_railways_api.Data.ApiAccess;
using irish_railways_api.Data.Stations;
using irish_railways_api.Models;
using irish_railways_api.Services.Stations;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Stations {
    [Route(ROUTE)]
    [ApiController]
    public class StationsController : ControllerBase {
        public const string ROUTE = "api/stations";
        private readonly StationsService stationsService = new StationsService(new StationRetriever(new ApiAccess<Station>()));

        [HttpGet]
        public IActionResult GetStations() {
            var result = stationsService.GetStations();

            return new OkObjectResult(result);
        }
    }
}