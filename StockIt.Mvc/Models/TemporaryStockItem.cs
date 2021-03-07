using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace StockIt.Core.Repositories.Stock
{
    public class TemporaryStockItem
    {
        public TemporaryStockItem()
        {
            StockActions = new List<SelectListItem>
            {
                new SelectListItem(StockAction.AddToStock.ToString(), (StockAction.AddToStock).ToString()),
                new SelectListItem(StockAction.RemoveFromStock.ToString(), (StockAction.RemoveFromStock).ToString())
            };

            StockActions2 = new List<ListItem2>
            {
                new ListItem2
                {
                    Id = 1,
                    Text = StockAction.AddToStock.ToString()
                },
                new ListItem2
                {
                    Id = 2,
                    Text = StockAction.RemoveFromStock.ToString()
                }
            };
        }
        public string Barcode { get; set; }

        public int StockActionItem { get; set; }

        public int StockActionId { get; set; }

        [DisplayName("Location")]
        public string LocationId { get; set; }

        public string Tenant { get; set; }
        public bool InErrorState { get; set; }

        public List<string> Errors { get; set; }

        public List<SelectListItem> StockActions { get; set; }

        public List<ListItem2> StockActions2 { get; set; }
    }

    public class ListItem2
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}