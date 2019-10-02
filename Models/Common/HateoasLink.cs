namespace irish_railways_api.Models.Common {
    public class HateoasLink {
        public const string GET_SELF = "self";

        public string Href { get; set; }

        public string Rel { get; set; }

        public string Method { get; set; }

        public HateoasLink(string href, string rel, HateoasMethod method) {
            Href = href;
            Rel = rel;
            Method = method.ToString();
        }
    }

    public enum HateoasMethod {
        GET
    }
}
