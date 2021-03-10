using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StockIt.Core.Repositories.Locations;
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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string LocationId { get; set; }
        public string Message { get; set; }

        protected bool saved = false;
        protected string message = string.Empty;
        protected string statusClass = string.Empty;

        public Location Location { get; set; } = new Location();

        protected override async Task OnInitializedAsync()
        {
            saved = false;

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

        protected async Task HandleInvalidSubmit()
        {
            saved = false;
            statusClass = "alert-danger";
            message = "Bad Location added successfully";
        }
            protected async Task HandleValidSubmit()
        {
            saved = false;

            if(string.IsNullOrEmpty(Location.Id))
            {
                var location = await LocationDataService.AddAsync(Location);

                if (location != null)
                {
                    saved = true;
                    statusClass = "alert-sucess";
                    message = "Location added successfully";
                }
                else
                {
                    saved = false;
                    statusClass = "alert-danger";
                    message = "Location added successfully";
                }
            }
            else
            {
                await LocationDataService.UpdateAsync(Location);
            }

            NavigationManager.NavigateTo("/locations");
        }
    }
}
