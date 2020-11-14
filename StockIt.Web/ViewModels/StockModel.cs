using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.ViewModels
{
    public class StockModel
    {
        public StockItActionType ActionType { get; set; }
    }

    public enum StockItActionType { ToStock, FromtStock, MoveStock };
}
