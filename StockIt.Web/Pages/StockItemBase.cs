using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Location;
using StockIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class StockItemBase : ComponentBase
    {
        protected bool saved = false;
        protected string message;
        protected string statusClass;
        protected List<StockItActionType> stockItActionTypes = StockItActionTypeConstants.ActionTypes;
        public Location Location { get; set; }
        public string ActionType { get; set; }
        public StockModel StockModel { get; set; } = new StockModel();

        protected async Task HandleValidSubmit()
        {
        }

        protected async Task SetActionType(int actionId)
        { }
    }
}
