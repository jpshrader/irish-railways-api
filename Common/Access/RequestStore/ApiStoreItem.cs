using irish_railways_api.Common.Resources;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access.RequestStore {
	public class ApiStoreItem {
		public IEnumerable<object> Item { get; set; }

		private readonly DateTime entryTime;

		public ApiStoreItem(IEnumerable<object> item) {
			Item = item;
			entryTime = DateTime.UtcNow;
		}

		public bool IsExpired(int rententionLimit) {
			return DateTime.UtcNow > entryTime.AddMinutes(rententionLimit);
		}
	}
}