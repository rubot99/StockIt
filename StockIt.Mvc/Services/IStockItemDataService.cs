using StockIt.Core.Repositories.StockItems;
using StockIt.Core.Repositories.Tenants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface IStockItemDataService : IDataService<StockItem>
    {
        Task<List<StockItem>> GetAllAsync(string tenant);
    }
}
