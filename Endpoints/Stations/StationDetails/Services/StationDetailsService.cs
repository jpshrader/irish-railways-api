using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.StationDetails.Adapters;
using irish_railways_api.Endpoints.Stations.StationDetails.Data;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;
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
			var stationData = stationDataRetriever.GetStationData(stationId);

			return new ResourceList<StationDetailsResource> {
				Resources = stationData.Select(detailsAdapter.Adapt),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.GET_SELF, routeArgs: stationId),
					HateoasLink.BuildGetLink(StationsController.ROUTE_SINGLE, "station", routeArgs: stationId)
				}
			};
		}
	}
}
