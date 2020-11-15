using StockIt.Core.Repositories.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.ViewModels
{
    public class StockModel
    {
        public StockItActionType ActionType { get; set; }

        public Location Location1 { get; set; }
        public Location Location2 { get; set; }
        public List<string> Barcodes { get; set; } = new List<string>();
    }

    public class ProductStockItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Barcode { get; set; } = string.Empty;

        public ProductStockItem(string barcode)
        {
            Barcode = barcode;
        }
    }
    
    public class ProductStock
    {
        public string Barcode { get; set; }

        public List<ProductLocation> AddItems { get; set; }
        public List<ProductLocation> RemoveItems { get; set; }

    }

    public class ProductLocation
    {
        public string LocationId { get; set; }
        public decimal Quantity { get; set; }
    }
}
