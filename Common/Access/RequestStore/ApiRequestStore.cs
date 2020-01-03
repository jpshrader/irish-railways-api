using irish_railways_api.Common.Resources;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access.RequestStore {
	public class ApiRequestStore : IApiRequestStore {
		private readonly Dictionary<Uri, ApiStoreItem<Resource>> apiRequestStore;
		private readonly int storeRetentionLimit;

		public ApiRequestStore(int storeRetentionLimit) {
			this.storeRetentionLimit = storeRetentionLimit;
			apiRequestStore = new Dictionary<Uri, ApiStoreItem<Resource>>();
		}

		public T Retrieve<T>(Uri url) where T : Resource {
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