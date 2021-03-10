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
        ///private readonly RecievedStockViewModel recievedStockViewModel;

        public StockItemController(ILocationDataService locationDataService, IStockItemDataService stockItemDataService)
        {
            this.locationDataService = locationDataService;
            this.stockItemDataService = stockItemDataService;
            ///recievedStockViewModel = new RecievedStockViewModel();
        }

        public async Task<IActionResult> Index()
        {
            var recievedStockItem = new RecievedStockItemViewModel
            {
                LocationList = new SelectList(await locationDataService.GetAllAsync(base.Tenant), "Id", "Name")
            };

            var tempData = TempData["RSID2"];

            int count = 0;
            if (tempData != null)
            {
                var recievedStockViewModel = JsonConvert.DeserializeObject<RecievedStockViewModel>(TempData["RSID2"].ToString());
                count = recievedStockViewModel.Items.Count;
            }

            ViewData["StockCount"] = count;

            return View(recievedStockItem);
        }

        [HttpPost]
        public IActionResult Index(RecievedStockItemViewModel recievedStockItemViewModel)
        {
            var tempData = TempData["RSID2"];
            RecievedStockViewModel recievedStockViewModel;

            if (tempData != null)
            {
                recievedStockViewModel = JsonConvert.DeserializeObject<RecievedStockViewModel>(tempData.ToString());
            }
            else
            {
                recievedStockViewModel = new RecievedStockViewModel();
                recievedStockViewModel.Id = Guid.NewGuid().ToString();
            }

            recievedStockItemViewModel.RecieveStockId = recievedStockViewModel.Id;
            recievedStockViewModel.Items.Add(recievedStockItemViewModel);

            TempData["RSID2"] = JsonConvert.SerializeObject(recievedStockViewModel);

            return RedirectToAction("Index");
        }
    }
}
