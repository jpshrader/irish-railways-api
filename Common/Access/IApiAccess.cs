using System;
using System.Collections.Generic;

namespace irish_railways_api.Common.Access {
	public interface IApiAccess<T> {
		IEnumerable<T> GetResources(Uri uri);
	}
}
