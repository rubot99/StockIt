using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories;
using StockIt.Core.Repositories.Product;
using StockIt.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class ProductListBase : ComponentBase
    { 
        protected List<Product> products;

        [Inject]
        public IProductDataService productDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            products = await productDataService.GetAllAsync("rrhome").ConfigureAwait(false);
        }
        protected async Task DeleteItem(string id)
        {
            await productDataService.DeleteAsync(id);
            products = await productDataService.GetAllAsync("rrhome").ConfigureAwait(false);
        }
        protected async Task EditItem(string id)
        {
            products = null;
            NavigationManager.NavigateTo($"product/{id}");
        }
        protected async Task AddItem()
        {
            products = null;
            NavigationManager.NavigateTo($"product");
        }
    }
}
