using System;
using System.Collections.Generic;

namespace StockIt.Core.Repositories.Products
{
    public class StoreItem
    {
        public string LocationId { get; set; }
        public string Location { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Updated { get; set; }
    }
}
