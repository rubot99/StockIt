////using System;
////using System.Collections.Generic;
////using System.ComponentModel;
////using System.Text;

////namespace StockIt.Core.Repositories.Stock
////{
////    public class TemporaryStockItem
////    {
////        public string Barcode { get; set; }

////        public StockAction StockAction { get; set; } = StockAction.AddToStock;

////        [DisplayName("Location")]
////        public string LocationId { get; set; }
////        public string Tenant { get; set; }
////        public bool InErrorState { get; set; }

////        public List<string> Errors { get; set; }
////    }
////}