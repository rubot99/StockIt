using System;
using System.Collections.Generic;

namespace StockIt.Mvc.Models
{
    public class RecievedStockViewModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
        public List<RecievedStockItemViewModel> Items { get; set; }
    }
}
