using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace irish_railways_api.Common.Access {
	public interface IApiAccess<T> {
		Task<IEnumerable<T>> GetResources(Uri uri);
	}
}
