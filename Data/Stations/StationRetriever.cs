using irish_railways_api.Data.ApiAccess;
using irish_railways_api.Models;
using System.Collections.Generic;

namespace irish_railways_api.Data.Stations {
    public class StationRetriever : IStationRetriever {
        private const string GET_ALL_STATIONS_URL = "http://api.irishrail.ie/realtime/realtime.asmx/getAllStationsXML";

        private readonly IApiAccess<Station> apiAccess;

        public StationRetriever(IApiAccess<Station> apiAccess) {
            this.apiAccess = apiAccess;
        }

        public IEnumerable<Station> GetStations() {
            return apiAccess.GetResources(GET_ALL_STATIONS_URL).Result;
        }
    }
}
