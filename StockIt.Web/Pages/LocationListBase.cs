using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Location;
using StockIt.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class LocationListBase : ComponentBase
    {
        protected List<Location> locations;

        [Inject]
        public ILocationDataService locationDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            locations = await locationDataService.GetAllAsync("new").ConfigureAwait(false);
        }
        protected async Task DeleteItem(string id)
        {
            await locationDataService.DeleteAsync(id);
        }
    }
}
