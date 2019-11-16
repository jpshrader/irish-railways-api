using irish_railways_api.Common.Resources;

namespace irish_railways_api.Controllers.Trains.Models {
	public class TrainResource : Resource {
		public string Code { get; set; }

		public string Status { get; set; }

		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public string Date { get; set; }

		public string PublicMessage { get; set; }

		public string Direction { get; set; }
	}
}
