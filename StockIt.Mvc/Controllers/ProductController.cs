﻿using Microsoft.AspNetCore.Mvc;
using StockIt.Core.Repositories.Product;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductDataService productDataService;

        public ProductController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await productDataService.GetAllAsync(base.Teanat).ConfigureAwait(false);
            return View(productList);
        }

        public async Task<IActionResult> Delete(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await productDataService.DeleteAsync(product.Id, base.Teanat).ConfigureAwait(false);
            return View();
        }

        public async Task<IActionResult> Edit(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }
    }
}
