using System.Collections.Generic;

namespace StockIt.Web.ViewModels
{
    public static class StockItActionTypeConstants
    {
        public static List<StockItActionType> ActionTypes = new List<StockItActionType>
        {
            new StockItActionType(1, "To Stock"),
            new StockItActionType(2, "From Stock"),
            new StockItActionType(3, "Move Stock"),
        };
    }
}