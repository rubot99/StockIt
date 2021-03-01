using StockIt.Core.Repositories.Tenant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface IStockItemDataService : IDataService<Tenant>
    {
        Task<List<KeyValuePair<string, string>>> GetStockActionsAsync();
    }
}
