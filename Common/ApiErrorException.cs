using System;
using System.Net;

namespace irish_railways_api.Common {
	public class ApiErrorException : Exception {
		public HttpStatusCode StatusCode { get; set; }

		public ApiErrorException(HttpStatusCode statusCode, string message) : base(message) {
			StatusCode = statusCode;
		}
	}
}
