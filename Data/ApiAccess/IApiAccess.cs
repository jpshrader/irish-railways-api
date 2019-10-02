using System.Collections.Generic;
using System.Threading.Tasks;

namespace irish_railways_api.Data.ApiAccess {
    public interface IApiAccess<T> {
        Task<IEnumerable<T>> GetResources(string url);
    }
}
