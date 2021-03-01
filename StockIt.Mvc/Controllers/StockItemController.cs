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

        public StockItemController(ILocationDataService locationDataService)
        {
            this.locationDataService = locationDataService;
        }

        public async Task<IActionResult> Index()
        {            
            ViewBag.LocationId = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name");
            ViewBag.StockActionId = new SelectList((from StockAction select { Id = }), "Id", "Name");

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
