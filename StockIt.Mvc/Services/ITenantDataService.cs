using StockIt.Core.Repositories.Tenants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface ITenantDataService : IDataService<Tenant>
    {
        Task<List<Tenant>> GetAllAsync();
    }
}
