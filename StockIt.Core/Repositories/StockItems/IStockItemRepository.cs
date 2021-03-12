using StockIt.Core.Repositories.StockItems;
using System.Collections.Generic;

namespace StockIt.Core.Repositories.Stock
{
    public interface IStockItemRepository : IRepository<StockItem>
    {
        List<StockItem> GetAll(string tenant);
    }
}