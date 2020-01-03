using irish_railways_api.Common.Resources;
using System;

namespace irish_railways_api.Common.Access.RequestStore {
	public class ApiStoreItem<T> where T : Resource {
		public T Item { get; set; }

		private readonly DateTime entryTime;

		public ApiStoreItem(T item) {
			Item = item;
			entryTime = DateTime.UtcNow;
		}

		public bool IsExpired(int rententionLimit) {
			return DateTime.UtcNow > entryTime.AddMinutes(rententionLimit);
		}
	}
}