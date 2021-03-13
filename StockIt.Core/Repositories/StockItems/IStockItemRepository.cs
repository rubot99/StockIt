using System.Collections.Generic;

namespace StockIt.Core.Repositories.StockItems
{
    public interface IStockItemRepository : IRepository<StockItem>
    {
        List<StockItem> GetAll(string tenant);
        StockItem Get(string id, string tenant);
    }
}