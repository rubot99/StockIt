using StockIt.Core.Repositories.Tenant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public interface ITenantDataService : IDataService<Tenant>
    {
        Task<List<Tenant>> GetAllAsync();
    }
}
