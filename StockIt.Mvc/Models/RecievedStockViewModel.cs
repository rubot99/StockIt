using System;
using System.Collections.Generic;

namespace StockIt.Mvc.Models
{
    public class RecievedStockViewModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
        public List<StockItemViewModel> Items { get; set; } = new List<StockItemViewModel>();
    }
}
