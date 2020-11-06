using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories.Tenant
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Tenant Get(string id);
        List<Tenant> GetAll();
    }
}
