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

        public Location Location { get; set; }
        public string ActionType { get; set; }
        public StockModel StockModel { get; set; }

        protected async Task HandleValidSubmit()
        {
        }
    }
}
