using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class ProductAddBase : ComponentBase
    {
        protected Product product;

        protected override async Task OnInitializedAsync()
        {
            product = new Product();
        }

        protected async Task HandleSubmit()
        { }
    }
}
