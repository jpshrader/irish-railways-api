using irish_railways_api.Common.Resources;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access.RequestStore {
	public class ApiStoreItem<T> where T : Resource {
		public IEnumerable<T> Item { get; set; }

		private readonly DateTime entryTime;

		public ApiStoreItem(IEnumerable<T> item) {
			Item = item;
			entryTime = DateTime.UtcNow;
		}

		public bool IsExpired(int rententionLimit) {
			return DateTime.UtcNow > entryTime.AddMinutes(rententionLimit);
		}
	}
}