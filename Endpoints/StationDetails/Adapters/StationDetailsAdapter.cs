﻿using irish_railways_api.Endpoints.StationDetails.Models;

namespace irish_railways_api.Endpoints.StationDetails.Adapters {
	public class StationDetailsAdapter : IStationDetailsAdapter {
		public StationDetailsResource Adapt(StationData stationData) {
			return new StationDetailsResource {
				StationCode = stationData.Stationcode,
				StationFullName = stationData.Stationfullname,
				TrainCode = stationData.Traincode.Trim(),
				Origin = stationData.Origin,
				Destination = stationData.Destination,
				DestinationTime = stationData.Destinationtime,
				DueIn = stationData.Duein,
				Late = stationData.Late,
				ScheduledDeparture = stationData.Schdepart,
				ScheduledArrival = stationData.Scharrival,
				ExpectedDeparture = stationData.Expdepart,
				ExpectedArrival = stationData.Exparrival,
				Traindate = stationData.Traindate,
				OriginTime = stationData.Origintime,
				TrainType = stationData.Traintype,
				LocationType = stationData.Locationtype,
				StaLastLocationTus = stationData.StaLastlocationtus
			};
		}
	}
}