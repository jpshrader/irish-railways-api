using irish_railways_api.Common.Resources;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access.RequestStore {
	public class ApiRequestStore : IApiRequestStore {
		private readonly Dictionary<string, ApiStoreItem<Resource>> apiRequestStore;
		private readonly int storeRetentionLimit;

		public ApiRequestStore(int storeRetentionLimit) {
			this.storeRetentionLimit = storeRetentionLimit;
			apiRequestStore = new Dictionary<string, ApiStoreItem<Resource>>();
		}

		public T Retrieve<T>(string url) where T : Resource {
			if (apiRequestStore.ContainsKey(url)) {
				var entry = apiRequestStore[url];
				if (!entry.IsExpired(storeRetentionLimit)) {
					return entry.Item as T;
				} else {
					apiRequestStore.Remove(url);
				}
			}

			return null;
		}
	}
}