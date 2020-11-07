using Microsoft.AspNetCore.Mvc;

namespace irish_railways_api.Common {
	public sealed class ApiVersion1 : ApiVersionAttribute {
		public ApiVersion1() : base("1.0") { }
	}
}
