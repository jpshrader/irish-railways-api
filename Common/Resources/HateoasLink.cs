using System.Text.RegularExpressions;

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

		public static HateoasLink BuildGetLink(string href, string rel, params string[] routeArgs) {
			return new HateoasLink(SpliceArgsIntoRoute(href, routeArgs), rel, HateoasMethod.GET);
		}

		private static string SpliceArgsIntoRoute(string href, params string[] routeArgs) {
			if (routeArgs.Length == 0)
				return href;

			var splicedHref = "";
			foreach (var arg in routeArgs) {
				var nextRouteVar = href.IndexOf('}') + 1;
				var isolatedArgString = href.Substring(0, nextRouteVar);
				splicedHref = Regex.Replace(isolatedArgString, "{.*}", arg);

				if (nextRouteVar != href.Length)
					splicedHref += href.Substring(nextRouteVar, href.Length - nextRouteVar);
			}

			return splicedHref;
		}
	}
}
