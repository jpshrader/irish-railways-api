﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.StationDetails.Adapters;
using irish_railways_api.Endpoints.StationDetails.Data;
using irish_railways_api.Endpoints.StationDetails.Models;
using irish_railways_api.Endpoints.Stations.StationDetails;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.StationDetails.Services {
	public class StationDetailsService : IStationDetailsService {
		private readonly IStationDetailsRetriever stationDataRetriever;
		private readonly IStationDetailsAdapter detailsAdapter;

		public StationDetailsService(IStationDetailsRetriever stationDataRetriever, IStationDetailsAdapter detailsAdapter) {
			this.stationDataRetriever = stationDataRetriever;
			this.detailsAdapter = detailsAdapter;
		}

		public ResourceList<StationDetailsResource> GetStationDetails(string stationName, string apiVersion) {
			return new ResourceList<StationDetailsResource> {
				Resources = GetStationDetailsResources(stationDataRetriever.GetStationData(stationName)),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.SELF, apiVersion, stationName),
					HateoasLink.BuildGetLink(StationsController.ROUTE_SINGLE, "station", apiVersion, stationName)
				}
			};
		}

		private IEnumerable<StationDetailsResource> GetStationDetailsResources(IEnumerable<StationDetail> stationData) {
			if (stationData == null)
				return Enumerable.Empty<StationDetailsResource>();

			return stationData.Select(detailsAdapter.Adapt).OrderBy(d => d.DueIn);
		}
	}
}
