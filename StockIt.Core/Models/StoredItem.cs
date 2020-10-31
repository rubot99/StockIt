using System;
using System.Collections.Generic;

namespace StockIt.Core.Models
{
    public class StoredItem
    {
        public string LocationId { get; set; }
        public double Quantity { get; set; }
        public DateTime Updated { get; set; }
    }
}
