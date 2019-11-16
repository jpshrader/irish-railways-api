using irish_railways_api.Controllers.Trains.Models;
using System.Collections.Generic;

namespace irish_railways_api.Trains.Data {
	public interface ITrainsRetriever {
		IEnumerable<Train> GetTrains();
	}
}
