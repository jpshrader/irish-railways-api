using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.StationDetails.Models;

namespace irish_railways_api.Endpoints.Stations.StationDetails.Adapters {
	public class StationDetailsAdapter : IStationDetailsAdapter {
		public StationDetailsResource Adapt(StationData stationData) {
			return new StationDetailsResource {
				Stationcode = stationData.Stationcode,
				Stationfullname = stationData.Stationfullname,
				Traincode = stationData.Traincode,
				Origin = stationData.Origin,
				Destination = stationData.Destination,
				Destinationtime = stationData.Destinationtime,
				Duein = stationData.Duein,
				Late = stationData.Late,
				Schdepart = stationData.Schdepart,
				Scharrival = stationData.Scharrival,
				Expdepart = stationData.Expdepart,
				Exparrival = stationData.Exparrival,
				Traindate = stationData.Traindate,
				Origintime = stationData.Origintime,
				Traintype = stationData.Traintype,
				Locationtype = stationData.Locationtype,
				StaLastlocationtus = stationData.StaLastlocationtus,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.SELF, routeArgs: stationData.Stationfullname),
					HateoasLink.BuildGetLink(StationsController.ROUTE_SINGLE, "station", routeArgs: stationData.Stationcode)
				}
			};
		}
	}
}
