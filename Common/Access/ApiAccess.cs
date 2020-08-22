using irish_railways_api.Common.Xml;
using irish_railways_api.EntryPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml;

namespace irish_railways_api.Common.Access {
	public class ApiAccess<T> : IApiAccess<T> {
		public IEnumerable<T> GetResources(Uri uri) {
			var requestStoreEntry = ApiRequestStoreSession.Store.Retrieve<T>(uri);
			if (requestStoreEntry != null)
				return requestStoreEntry;

			using var httpClient = new HttpClient();
			var response = httpClient.GetAsync(uri).Result;

			if (response.IsSuccessStatusCode) {
				var serialiser = XmlSerialiserFactory.GetXmlSerialiser<T>();
				using var reader = XmlReader.Create(response.Content.ReadAsStreamAsync().Result);
				var result = ((IXmlNode<T>)serialiser.Deserialize(reader)).Items;

				if (result != null)
					ApiRequestStoreSession.Store.Save(uri, result as object[]);

				return result ?? Enumerable.Empty<T>();
			}

			throw new ApiErrorException(response.StatusCode, response.Content.ReadAsStringAsync().Result);
		}
	}
}
