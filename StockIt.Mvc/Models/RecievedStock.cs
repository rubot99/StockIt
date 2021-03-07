using StockIt.Core.Repositories.Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Mvc.Models
{
    public class RecievedStock
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
        public List<RecievedStockItem> Items { get; set; }
    }

    public class RecievedStockItem
    {
        public RecievedStockItem(string recieveStockId)
        {
            Id = Guid.NewGuid().ToString();
            RecieveStockId = recieveStockId;
        }

        public string RecieveStockId { get; private set; }
        public string Id { get; private set; }
        public string Barcode { get; set; }

        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }
    }
}
