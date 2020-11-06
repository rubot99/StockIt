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

        protected override async Task OnInitializedAsync()
        {
            products = await productDataService.GetAllAsync("new").ConfigureAwait(false);
        }
        protected async Task DeleteItem(string id)
        {
            await productDataService.DeleteAsync(id);
        }
    }
}
