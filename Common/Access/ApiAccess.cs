using irish_railways_api.Common.Xml;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace irish_railways_api.Common.Access {
	public class ApiAccess<T> : IApiAccess<T> {
		public IEnumerable<T> GetResources(Uri uri) {
			// TODO: Call out to Singleton Store, and pass Uri. If not null, return.
			var requestEntry = uri as IEnumerable<T>;
			if (requestEntry != null) {
				return requestEntry;
			}

			using var httpClient = new HttpClient();
			var response = httpClient.GetAsync(uri).Result;

			if (response.IsSuccessStatusCode) {
				var serialiser = XmlSerialiserFactory.GetXmlSerialiser<T>();

				using var reader = XmlReader.Create(response.Content.ReadAsStreamAsync().Result);
				var result = ((IXmlNode<T>)serialiser.Deserialize(reader)).Items;

				// TODO: Save result to store

				return result;
			}

			throw new ApiErrorException(response.StatusCode, response.Content.ReadAsStringAsync().Result);
		}
	}
}
