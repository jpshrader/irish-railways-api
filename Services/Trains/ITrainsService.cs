using irish_railways_api.Controllers.Trains.Models;

namespace irish_railways_api.Services.Trains {
    public interface ITrainsService {
        TrainsResource GetTrains();
    }
}
