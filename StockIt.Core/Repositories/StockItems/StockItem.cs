using System;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.StockItems
{
    public class StockItem : BaseTenantModel
    {
        [Required]
        public string Id { get; private set; }

        [Required]
        public string Barcode { get; set; }

        [Required]
        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }

        [Required]
        public string LocationId { get; set; }

        public bool IsProcessed { get; set; }

        public bool InError { get; set; }

        public DateTime Created { get; set; }
    }
}
