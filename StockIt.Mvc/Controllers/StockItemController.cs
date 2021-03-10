using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Core.Repositories.Locations;
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
        private readonly RecievedStockViewModel recievedStockViewModel;

        public StockItemController(ILocationDataService locationDataService, IStockItemDataService stockItemDataService)
        {
            this.locationDataService = locationDataService;
            this.stockItemDataService = stockItemDataService;
            recievedStockViewModel = new RecievedStockViewModel();
        }

        public async Task<IActionResult> Index()
        {
            var recievedStockItem = new RecievedStockItemViewModel
            {
                LocationList = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name")
            };

            TempData["RSID"] = recievedStockItem.Id;

            return View(recievedStockItem);
        }

        [HttpPost]
        public IActionResult Index(RecievedStockItemViewModel recievedStockItem)
        {
            var isd = TempData["RSID"];
            return View();
        }
    }
}
