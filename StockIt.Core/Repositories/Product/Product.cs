using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockIt.Core.Repositories.Product
{
    public class Product : BaseTenantModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal AlertQuantity { get; set; }
        public decimal TotalQuantity { get; set; }
        public List<StoreItem> StoreItems { get; set; } = new List<StoreItem>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
