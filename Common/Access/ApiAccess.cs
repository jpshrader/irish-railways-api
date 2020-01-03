using irish_railways_api.Common.Xml;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace irish_railways_api.Common.Access {
	public class ApiAccess<T> : IApiAccess<T> {
		public async Task<IEnumerable<T>> GetResources(Uri uri) {
			// TODO: Call out to Singleton Store, and pass Uri. If not null, return.
			var requestEntry = uri as IEnumerable<T>;
			if (requestEntry != null) {
				return requestEntry;
			}

			using var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(uri);

			if (response.IsSuccessStatusCode) {
				var serialiser = XmlSerialiserFactory.GetXmlSerialiser<T>();

				using var reader = XmlReader.Create(await response.Content.ReadAsStreamAsync());
				return ((IXmlNode<T>)serialiser.Deserialize(reader)).Items;
			}

			throw new ApiErrorException(response.StatusCode, await response.Content.ReadAsStringAsync());
		}
	}
}
