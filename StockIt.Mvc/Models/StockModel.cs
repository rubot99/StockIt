﻿using StockIt.Core.Repositories.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Mvc.Models
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

        public List<ProductLocation> AddItems { get; set; } = new List<ProductLocation>();
        public List<ProductLocation> RemoveItems { get; set; } = new List<ProductLocation>();

    }

    public class ProductLocation
    {
        public string LocationId { get; set; }
        public decimal Quantity { get; set; }
    }
}
