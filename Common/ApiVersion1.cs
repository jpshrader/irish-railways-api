using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Common {
	public sealed class ApiVersion1 : ApiVersionAttribute {
		public const string VERSION = "1.0";

		public ApiVersion1() : base(VERSION) { }
	}
}
