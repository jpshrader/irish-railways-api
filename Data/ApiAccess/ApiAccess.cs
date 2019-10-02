using irish_railways_api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace irish_railways_api.Data.ApiAccess {
    public class ApiAccess<T> : IApiAccess<T> {
        private readonly XmlSerialiserFactory xmlReaderFactory = new XmlSerialiserFactory();

        public async Task<IEnumerable<T>> GetResources(string url) {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var serialiser = xmlReaderFactory.GetXmlSerialiser(typeof(T));

                using var reader = XmlReader.Create(await response.Content.ReadAsStreamAsync());
                return ((IApiList<T>)serialiser.Deserialize(reader)).Items;
            }

            throw new ApiErrorException(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
