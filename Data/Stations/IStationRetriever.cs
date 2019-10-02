using irish_railways_api.Models;
using System.Collections.Generic;

namespace irish_railways_api.Data.Stations {
    public interface IStationRetriever {
        IEnumerable<Station> GetStations();
    }
}
