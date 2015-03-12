using System.Collections.Generic;
using System.Threading.Tasks;
using MicroB2c.Core.DbModel;

namespace MicroB2c.Core.IDAL
{
    public interface IWebContentDal : IDataOperationActivity<WebContent>
    {
        IEnumerable<WebContent> QueryByWebContentTypeIds(List<int> ids);

        Task<IEnumerable<WebContent>> QueryByWebContentTypeIdsAsync(List<int> ids);
    }
}
