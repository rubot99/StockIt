using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockIt.Core.Repositories.Locations;
using StockIt.Mvc.Models;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class StockItemController : BaseController
    {
        private readonly ILocationDataService locationDataService;
        private readonly IStockItemDataService stockItemDataService;

        public StockItemController(ILocationDataService locationDataService, IStockItemDataService stockItemDataService)
        {
            this.locationDataService = locationDataService;
            this.stockItemDataService = stockItemDataService;
        }

        public async Task<IActionResult> Index()
        {
            var stockItems = await stockItemDataService.GetAllAsync(base.Tenant);

            return View(stockItems);
        }

        public async Task<IActionResult> Create()
        {
            var recievedStockItem = new StockItemViewModel
            {
                LocationList = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name")
            };

            return View(recievedStockItem);
        }

        [HttpPost]
        public IActionResult Create(StockItemViewModel recievedStockItemViewModel)
        {
            var item = new Re
            stockItemDataService.AddAsync(recievedStockItemViewModel);
            return RedirectToAction("Index");
        }
    }
}
