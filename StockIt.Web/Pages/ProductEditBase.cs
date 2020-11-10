using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Location;
using StockIt.Core.Repositories.Product;
using StockIt.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class ProductEditBase : ComponentBase
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ProductId { get; set; }
        public string Message { get; set; }
        public string Tags { get; set; }

        public double ProductQuantity { get; set; }
        public string LocationName { get; set; }

        public Product ProductItem { get; set; } = new Product();
        public List<Location> Locations { get; set; } = new List<Location>();

        protected override async Task OnInitializedAsync()
        {
            // Saved = false;
            if (string.IsNullOrEmpty(ProductId)) //new employee is being created
            {
                //add some defaults
                ProductItem = new Product { Id = string.Empty, Tenant = "rrhome" };
            }
            else
            {
                ProductItem = await ProductDataService.GetAsync(ProductItem.Id, "rrhome");
                Tags = string.Join(',', ProductItem.Tags);
            }

            ProductItem.StoreItems.Add(new StoreItem
            {
                LocationId = "234234",
                Location = "Garage",
                Quantity = 20,
                Updated = DateTime.Now
            });

            ProductItem.StoreItems.Add(new StoreItem
            {
                LocationId = "435",
                Location = "House",
                Quantity = 43,
                Updated = DateTime.Now
            });

            Locations.Add(new Location
            {
                Id = Guid.NewGuid().ToString(),
                Name = "House"
            });

            Locations.Add(new Location
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Garage"
            });
        }

        protected async Task HandleValidSubmit()
        {
            ProductItem.Tags = Tags.Split(',').ToList<string>();

            if (string.IsNullOrEmpty(ProductItem.Id))
            {                
                await ProductDataService.AddAsync(ProductItem);
            }
            else
            {

            }

            NavigationManager.NavigateTo("/product");
        }

        protected async Task AddStoreItem()
        {
            ProductItem.StoreItems.Add(
                new StoreItem
                {
                    Location = LocationName,
                    Quantity = ProductQuantity
                });

            LocationName = string.Empty;
            ProductQuantity = 0;
        }

        protected async Task DeleteStoreItem()
        {
        }
    }
}
