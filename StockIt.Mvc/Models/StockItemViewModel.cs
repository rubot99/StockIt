using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Core.Repositories.StockItems;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Mvc.Models
{
    public class StockItemViewModel
    {
        [Required]
        public string Barcode { get; set; }

        [Required]
        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }

        [Required]
        public string LocationId { get; set; }

        public SelectList LocationList { get; set; }

        public StockItem ConvertToStockItem()
        {
            return new StockItem
            {
                Barcode = this.Barcode,
                ActionType = this.ActionType,
                LocationId = this.LocationId
            };
        }
    }

}