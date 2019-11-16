using System.Collections.Generic;

namespace irish_railways_api.Common.Resources {
	public class ResourceList<T> where T : Resource {
		public IEnumerable<T> Resources { get; set; }

		public IEnumerable<HateoasLink> Links { get; set; }
	}
}
