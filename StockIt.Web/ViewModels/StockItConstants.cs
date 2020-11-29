using System.Collections.Generic;

namespace StockIt.Web.ViewModels
{
    public static class StockItConstants
    {
        public static List<StockItActionType> ActionTypes = new List<StockItActionType>
        {
            new StockItActionType(1, StockItActionItem.ToStock, "To Stock"),
            new StockItActionType(2, StockItActionItem.FromStock, "From Stock"),
            new StockItActionType(3, StockItActionItem.MoveStock, "Move Stock"),
        };
    }

    public enum StockItActionItem
    {
        ToStock,
        FromStock,
        MoveStock
    }
}