using irish_railways_api.Controllers.Trains.Models;
using System.Collections.Generic;

namespace irish_railways_api.Data.Trains {
    public interface ITrainsRetriever {
        IEnumerable<Train> GetTrains();
    }
}
