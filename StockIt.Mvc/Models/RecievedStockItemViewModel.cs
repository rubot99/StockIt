﻿using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Core.Repositories.StockItems;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Mvc.Models
{
    public class RecievedStockItemViewModel
    {
        [Required]
        public string RecieveStockId { get; set; }

        [Required]
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        [Required]
        public string Barcode { get; set; }

        [Required]
        [EnumDataType(typeof(StockAction))]
        public StockAction ActionType { get; set; }

        [Required]
        public string LocationId { get; set; }

        public SelectList LocationList { get; set; }
    }
}