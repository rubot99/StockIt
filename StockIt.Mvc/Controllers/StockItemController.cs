using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Core.Repositories.Location;
using StockIt.Core.Repositories.Stock;
using StockIt.Mvc.Models;
using StockIt.Mvc.Services;
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
            var l = new List<Location>
            {
                new Location
                {
                    Id = "1",
                    Name="dsfsd",
                },
                new Location
                {
                    Id = "2",
                    Name="dsfsdfdsfsd",
                }
            };

            /////ViewData["LocationId"] = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name");
            var k = new SelectList(await stockItemDataService.GetStockActionsAsync(), "Value", "Text");
            ViewData["StockActionId"] = k;
            var r = new RecievedStockItem("sdffd");
            r.LocationList = new SelectList(l, "Id", "Name");

            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind(include: "LocationId, Barcode, StockActionId")] TemporaryStockItem stockItem)
        {
            stockItem.Tenant = base.Tenant;

            return View();
        }

        [HttpGet("tr")]
        public async Task<IActionResult> Create()
        {
            return View("Viewewewew");
        }
    }
}
