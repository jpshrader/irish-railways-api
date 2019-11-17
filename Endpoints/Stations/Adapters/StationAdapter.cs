﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.Models;
using irish_railways_api.Endpoints.Stations.StationDetails;
using irish_railways_api.Models;

namespace irish_railways_api.Endpoints.Stations.Adapters {
	public class StationAdapter : IStationAdapter {
		public StationResource Adapt(Station station) {
			return new StationResource {
				Id = station.StationId,
				Name = station.StationDesc,
				Code = station.StationCode,
				Alias = station.StationAlias,
				Latitude = station.StationLatitude,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationsController.ROUTE, HateoasLink.GET_SELF),
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.GET_SELF_DETAILED, routeArgs: station.StationCode)
				}
			};
		}
	}
}
