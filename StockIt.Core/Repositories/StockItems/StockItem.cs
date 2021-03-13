using System;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.StockItems
{
    public class StockItem : BaseTenantModel
    {
        public string Id { get; set; }

        [Required]
        public string Barcode { get; set; }

        [Required]
        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }

        [Required]
        public string LocationId { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsProcessed { get; set; }

        public bool InError { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
