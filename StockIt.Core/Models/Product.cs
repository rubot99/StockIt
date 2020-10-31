﻿using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public double AlertQuantity { get; set; }
        public List<StoredItem> StoredItems { get; set; } = new List<StoredItem>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
