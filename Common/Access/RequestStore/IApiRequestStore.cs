using irish_railways_api.Common.Resources;
using System;

namespace irish_railways_api.Common.Access.RequestStore {
	public interface IApiRequestStore {
		T Retrieve<T>(Uri url) where T : Resource;
	}
}