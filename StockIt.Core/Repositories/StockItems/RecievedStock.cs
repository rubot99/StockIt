using System;
using System.Collections.Generic;

namespace StockIt.Core.Repositories.StockItems
{
    public class RecievedStock
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
        public List<RecievedStockItem> Items { get; set; }
    }
}
