using irish_railways_api.Common.Access.RequestStore;
using System;

namespace irish_railways_api.EntryPoint {
	public static class ApiRequestStoreSession {
		private static readonly Lazy<ApiRequestStore> instance = new Lazy<ApiRequestStore>(() => new ApiRequestStore(storeRetentionLimit: RetentionPolicy), isThreadSafe: true);

		public static bool IsEnabled { get; set; }

		public static int RetentionPolicy { get; set; }

		public static ApiRequestStore Store => instance.Value;
	}
}
