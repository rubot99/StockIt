using System;
using System.Collections.Generic;

namespace StockIt.Core.Repositories.Product
{
    public class StoreItem
    {
        public string LocationId { get; set; }
        public string Location { get; set; }
        public double Quantity { get; set; }
        public DateTime Updated { get; set; }
    }
}
