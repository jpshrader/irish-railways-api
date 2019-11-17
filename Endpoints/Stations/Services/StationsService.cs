﻿using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.Adapters;
using irish_railways_api.Endpoints.Stations.Data;
using irish_railways_api.Endpoints.Stations.Models;
using irish_railways_api.Models;
using System.Collections.Generic;
using System.Linq;

namespace irish_railways_api.Endpoints.Stations.Services {
	public class StationsService : IStationsService {
		private readonly IStationRetriever stationRetriever;
		private readonly IStationAdapter stationAdapter;

		public StationsService(IStationRetriever stationRetriever, IStationAdapter stationAdapter) {
			this.stationRetriever = stationRetriever;
			this.stationAdapter = stationAdapter;
		}

		public ResourceList<StationResource> GetStations() {
			return new ResourceList<StationResource> {
				Resources = GetStationResources(stationRetriever.GetStations()),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationsController.ROUTE, HateoasLink.GET_SELF)
				}
			};
		}

		public StationResource GetStation(string stationId) {
			var station = stationRetriever.GetStations().SingleOrDefault(s => s.StationId == stationId);

			if (station == null)
				return null;

			return stationAdapter.Adapt(station);
		}

		private IEnumerable<StationResource> GetStationResources(IEnumerable<Station> stations) {
			if (stations == null)
				return Enumerable.Empty<StationResource>();

			return stations.Select(stationAdapter.Adapt);
		}
	}
}
