using irish_railways_api.Common.Resources;
using System;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access.RequestStore {
	public interface IApiRequestStore {
		IEnumerable<T> Retrieve<T>(Uri url) where T : Resource;
	}
}