using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Data.ApiAccess;
using irish_railways_api.Data.Trains;
using irish_railways_api.Services.Trains;
using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Controllers.Trains {
    [Route(ROUTE)]
    [ApiController]
    public class TrainsController {
        public const string ROUTE = "api/trains";
        private readonly TrainsService trainsService = new TrainsService(new TrainsRetriever(new ApiAccess<Train>()));

        [HttpGet]
        public IActionResult GetTrains() {
            var result = trainsService.GetTrains();

            return new OkObjectResult(result);
        }
    }
}
