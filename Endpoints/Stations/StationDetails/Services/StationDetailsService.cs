using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.StationDetails.Adapters;
using irish_railways_api.Endpoints.Stations.StationDetails.Data;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Services {
	public class StationDetailsService : IStationDetailsService {
		private readonly IStationDataRetriever stationDataRetriever;
		private readonly IStationDetailsAdapter detailsAdapter;

		public StationDetailsService(IStationDataRetriever stationDataRetriever, IStationDetailsAdapter detailsAdapter) {
			this.stationDataRetriever = stationDataRetriever;
			this.detailsAdapter = detailsAdapter;
		}

		public ResourceList<StationDetailsResource> GetStationDetails(string stationId) {
			return new ResourceList<StationDetailsResource> {
				Resources = GetStationDetailsResources(stationDataRetriever.GetStationData(stationId)),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.GET_SELF, routeArgs: stationId),
					HateoasLink.BuildGetLink(StationsController.ROUTE_SINGLE, "station", routeArgs: stationId)
				}
			};
		}

		private IEnumerable<StationDetailsResource> GetStationDetailsResources(IEnumerable<StationData> stationData) {
			if (stationData == null)
				return Enumerable.Empty<StationDetailsResource>();

			return stationData.Select(detailsAdapter.Adapt);
		}
	}
}
