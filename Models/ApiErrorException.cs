using System;
using System.Net;

namespace irish_railways_api.Models {
    public class ApiErrorException : Exception {
        public ApiErrorException(HttpStatusCode statusCode, string message) : base(message) {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
