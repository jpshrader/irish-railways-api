﻿using irish_railways_api.Common.Resources;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Models {
	public class StationDetailsResource : Resource {
		public string Traincode { get; set; }

		public string Stationfullname { get; set; }

		public string Stationcode { get; set; }

		public string Traindate { get; set; }

		public string Origin { get; set; }

		public string Destination { get; set; }

		public string Origintime { get; set; }

		public string Destinationtime { get; set; }

		public string StaLastlocationtus { get; set; }

		public int Duein { get; set; }

		public int Late { get; set; }

		public string Exparrival { get; set; }

		public string Expdepart { get; set; }

		public string Scharrival { get; set; }

		public string Schdepart { get; set; }

		public string Traintype { get; set; }

		public string Locationtype { get; set; }
	}
}
