using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Stock { get; set; }
        public List<string> Barcodes { get; set; } = new List<string>();
        public string Location { get; set; }
    }
}
