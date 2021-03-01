using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StockIt.Core.Repositories.Stock
{
    public class TemporaryStockItem
    {
        public TemporaryStockItem()
        {
            StockActions = new List<SelectListItem>
            { 
                new SelectListItem(StockAction.AddToStock.ToString(), ((int)StockAction.AddToStock).ToString()),
                new SelectListItem(StockAction.RemoveFromStock.ToString(), ((int)StockAction.RemoveFromStock).ToString())
            };
        }
        public string Barcode { get; set; }

        public int StockActionItem { get; set; }

        public string StockActionId { get; set; }

        [DisplayName("Location")]
        public string LocationId { get; set; }
        public string Tenant { get; set; }
        public bool InErrorState { get; set; }

        public List<string> Errors { get; set; }

        public List<SelectListItem> StockActions { get; set; }
    }
}