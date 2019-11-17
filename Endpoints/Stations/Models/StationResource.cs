﻿using irish_railways_api.Common.Resources;

namespace irish_railways_api.Endpoints.Stations.Models {
	public class StationResource : Resource {
		public string Id { get; set; }

		public string Name { get; set; }

		public string Alias { get; set; }

		public decimal Latitude { get; set; }

		public string Code { get; set; }
	}
}
