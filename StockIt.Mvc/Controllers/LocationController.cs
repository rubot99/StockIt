using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationDataService locationDataService;

        public LocationController(ILocationDataService locationDataService)
        {
            this.locationDataService = locationDataService;
        }

        public async Task<IActionResult> Index()
        {
            var locationList = await locationDataService.GetAllAsync("rrhome").ConfigureAwait(false);
            return View(locationList);
        }

        public async Task<IActionResult> Edit(string id, string tenant)
        {
            var location = await locationDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(location);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(string id, string tenant)
        {
            var location = await locationDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(location);
        }
    }
}
