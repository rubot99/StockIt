using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Location;
using StockIt.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class LocationEditBase : ComponentBase
    {
        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        [Parameter]
        public string LocationId { get; set; }
        public string Message { get; set; }

        public Location Location { get; set; } = new Location();

        protected override async Task OnInitializedAsync()
        {
            // Saved = false;
            if (string.IsNullOrEmpty(LocationId)) //new employee is being created
            {
                //add some defaults
                Location = new Location { Id =  string.Empty, Tenant = "rrhome" };
            }
            else
            {
                Location = await LocationDataService.GetAsync(LocationId, "rrhome");
            }

        }

        protected async Task HandleValidSubmit()
        {
            if(string.IsNullOrEmpty(Location.Id))
            {
                await LocationDataService.AddAsync(Location);
            }
            else
            {
                
            }
        }
    }
}
