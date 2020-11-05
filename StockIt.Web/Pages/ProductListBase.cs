using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories;
using StockIt.Core.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class ProductListBase : ComponentBase
    { 
        protected List<Product> products;

        protected override async Task OnInitializedAsync()
        {
            products = new List<Product>
            {
                new Product
                {
                    Id = "kkk"
                },
                new Product
                {
                    Id = "kkkikpkpo"
                }
            };
        }
    }
}
