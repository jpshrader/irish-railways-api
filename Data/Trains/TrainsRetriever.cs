using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Data.ApiAccess;
using System.Collections.Generic;

namespace irish_railways_api.Data.Trains {
    public class TrainsRetriever : ITrainsRetriever {
        private const string GET_CURRENT_TRAINS_URL = "http://api.irishrail.ie/realtime/realtime.asmx/getCurrentTrainsXML";

        private readonly IApiAccess<Train> apiAccess;

        public TrainsRetriever(IApiAccess<Train> apiAccess) {
            this.apiAccess = apiAccess;
        }

        public IEnumerable<Train> GetTrains() {
            return apiAccess.GetResources(GET_CURRENT_TRAINS_URL).Result;
        }
    }
}
