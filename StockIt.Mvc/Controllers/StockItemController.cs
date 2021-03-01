using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Core.Repositories.Stock;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

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
            ViewBag.LocationId = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name");
            ViewBag.StockActionId = new SelectList(await stockItemDataService.GetStockActionsAsync(), "Id", "Name");

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind(include:"LocationId, Barcode, StockActionId")] TemporaryStockItem stockItem)
        {
            stockItem.Tenant = base.Tenant;

            return View();
        }
    }
}
