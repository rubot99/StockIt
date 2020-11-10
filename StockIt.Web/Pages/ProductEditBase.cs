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
        public ILocationDataService LocationDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ProductId { get; set; }
        public string Message { get; set; }
        public string Tags { get; set; }

        public double ProductQuantity { get; set; } = 1;
        public string LocationName { get; set; }
        public string LocationId { get; set; }

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

            Locations = await LocationDataService.GetAllAsync("rrhome");
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
                await ProductDataService.UpdateAsync(ProductItem);
            }

            NavigationManager.NavigateTo("/product");
        }

        protected async Task AddStoreItem(string locationId, double productQuantity)
        {
            var location = Locations.FirstOrDefault<Location>(x => x.Id.Equals(locationId, StringComparison.OrdinalIgnoreCase));

            if(location != null)
            {
                if (!ProductItem.StoreItems.Exists(x => x.LocationId.Equals(location.Id, StringComparison.OrdinalIgnoreCase)))
                {
                    ProductItem.StoreItems.Add(
                    new StoreItem
                    {
                        LocationId = location.Id,
                        Location = location.Name,
                        Quantity = ProductQuantity
                    });
                }
            }
            
            LocationId = string.Empty;
            ProductQuantity = 1;
        }

        protected async Task DeleteStoreItem(string locationId)
        {
            if (ProductItem.StoreItems.Exists(x => x.LocationId.Equals(locationId, StringComparison.OrdinalIgnoreCase)))
            {
                ProductItem.StoreItems.RemoveAll(x => x.LocationId.Equals(locationId, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
