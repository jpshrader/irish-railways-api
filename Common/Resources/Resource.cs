﻿using System.Collections.Generic;

namespace irish_railways_api.Common.Resources {
	public abstract class Resource<T> {
		public IEnumerable<T> Resources { get; set; }

		public IEnumerable<HateoasLink> Links { get; set; }
	}
}
