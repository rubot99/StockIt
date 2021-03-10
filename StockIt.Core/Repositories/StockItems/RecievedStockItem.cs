using System;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.StockItems
{
    public class RecievedStockItem
    {
        [Required]
        public string RecieveStockId { get; private set; }

        [Required]
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        [Required]
        public string Barcode { get; set; }

        [Required]
        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }

        [Required]
        public string LocationId { get; set; }
    }
}
