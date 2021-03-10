using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Locations;
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
        public ILocationDataService LocationDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            locations = await LocationDataService.GetAllAsync("rrhome").ConfigureAwait(false);
        }
        protected async Task DeleteItem(string id)
        {
            await LocationDataService.DeleteAsync(id);
            locations = await LocationDataService.GetAllAsync("rrhome").ConfigureAwait(false);
        }

        protected async Task EditItem(string id)
        {
            locations = null;
            NavigationManager.NavigateTo($"location/{id}");
        }
        protected async Task AddItem()
        {
            locations = null;
            NavigationManager.NavigateTo($"location");
        }
    }
}
