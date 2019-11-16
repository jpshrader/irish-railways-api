namespace irish_railways_api.Common.Resources {
	public class HateoasLink {
		public const string GET_SELF = "self";
		public const string GET_SELF_DETAILED = "self_detailed";

		public string Href { get; set; }

		public string Rel { get; set; }

		public string Method { get; set; }

		public HateoasLink(string href, string rel, HateoasMethod method) {
			Href = href;
			Rel = rel;
			Method = method.ToString();
		}

		public static HateoasLink BuildGetLink(string href, string rel) {
			return new HateoasLink(href, rel, HateoasMethod.GET);
		}
	}
}
