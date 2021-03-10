using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories.Tenants
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Tenant Get(string id);
        List<Tenant> GetAll();
    }
}
