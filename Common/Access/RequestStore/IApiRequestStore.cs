using irish_railways_api.Common.Resources;

namespace irish_railways_api.Common.Access.RequestStore {
	public interface IApiRequestStore {
		T Retrieve<T>(string url) where T : Resource;
	}
}