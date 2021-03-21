using irish_railways_api.Common.Resources;
using irish_railways_api.Controllers.Stations;
using irish_railways_api.Endpoints.Stations.Adapters;
using irish_railways_api.Endpoints.Stations.Data;
using irish_railways_api.Endpoints.Stations.Models;
using irish_railways_api.Models;
using System;
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

		public ResourceList<StationResource> GetStations(string apiVersion) {
			return new ResourceList<StationResource> {
				Resources = GetStationResources(stationRetriever.GetStations(), apiVersion),
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationsController.ROUTE, HateoasLink.SELF, apiVersion)
				}
			};
		}

		public StationResource GetStation(string stationName, string apiVersion) {
			var station = stationRetriever.GetStations().FirstOrDefault(s => s.StationDesc.Equals(stationName, StringComparison.OrdinalIgnoreCase));

			if (station == null)
				return null;

			return stationAdapter.Adapt(station, apiVersion);
		}

		private IEnumerable<StationResource> GetStationResources(IEnumerable<Station> stations, string apiVersion) {
			if (stations == null)
				return Enumerable.Empty<StationResource>();

			return stations.Select(s => stationAdapter.Adapt(s, apiVersion)).OrderBy(s => s.Name);
		}
	}
}
