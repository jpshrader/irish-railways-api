using irish_railways_api.Models.Common;

namespace irish_railways_api.Models {
    public class Station {
        public string StationId { get; set; }

        public string StationAlias { get; set; }

        public string StationLatitude { get; set; }

        public string StationCode { get; set; }

        public string StationDesc { get; set; }
    }

    //TDOD: Organise these better
    public class StationResource : Resource<Station> {
    }
}
