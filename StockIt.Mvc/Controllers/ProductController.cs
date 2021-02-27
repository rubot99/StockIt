using Microsoft.AspNetCore.Mvc;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDataService productDataService;

        public ProductController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await productDataService.GetAllAsync("rrhome").ConfigureAwait(false);
            return View(productList);
        }

        public async Task<IActionResult> Delete(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }

        public async Task<IActionResult> Edit(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }
    }
}
