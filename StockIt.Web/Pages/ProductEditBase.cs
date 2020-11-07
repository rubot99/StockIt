using Microsoft.AspNetCore.Components;
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

        [Parameter]
        public string ProductId { get; set; }
        public string Message { get; set; }

        public Product Product { get; set; } = new Product();

        protected override async Task OnInitializedAsync()
        {
            // Saved = false;
            if (string.IsNullOrEmpty(ProductId)) //new employee is being created
            {
                //add some defaults
                Product = new Product { Id = string.Empty, Tenant = "rrhome" };
            }
            else
            {
                Product = await ProductDataService.GetAsync(Product.Id, "rrhome");
            }

        }

        protected async Task HandleValidSubmit()
        {
            if (string.IsNullOrEmpty(Product.Id))
            {
                await ProductDataService.AddAsync(Product);
            }
            else
            {

            }
        }
    }
}
