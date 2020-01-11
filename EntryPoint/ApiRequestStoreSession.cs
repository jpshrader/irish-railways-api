using irish_railways_api.Common.Access.RequestStore;
using System;

namespace irish_railways_api.EntryPoint {
	public static class ApiRequestStoreSession {
		private static readonly Lazy<ApiRequestStore> instance = new Lazy<ApiRequestStore>(() => new ApiRequestStore(storeRetentionLimit: 2), isThreadSafe: true);

		public static ApiRequestStore Store => instance.Value;
	}
}
