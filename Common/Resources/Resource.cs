﻿using System.Collections.Generic;

namespace irish_railways_api.Common.Resources {
	public abstract class Resource {
		public IEnumerable<HateoasLink> Links { get; set; }
	}
}
