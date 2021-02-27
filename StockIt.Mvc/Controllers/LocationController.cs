using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockIt.Core.Repositories.Location;
using StockIt.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class LocationController : BaseController
    {
        private readonly ILocationDataService locationDataService;

        public LocationController(ILocationDataService locationDataService)
        {
            this.locationDataService = locationDataService;
        }

        public async Task<IActionResult> Index()
        {
            var locationList = await locationDataService.GetAllAsync(base.Teanat).ConfigureAwait(false);
            return View(locationList);
        }

        public async Task<IActionResult> Edit(string id, string tenant)
        {
            var location = await locationDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Location location)
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location location)
        {
            location.Enabled = true;
            location.Tenant = base.Teanat;
            await locationDataService.AddAsync(location).ConfigureAwait(false);

            return RedirectToAction("Index", "Location");
        }

        public async Task<IActionResult> Delete(string id, string tenant)
        {
            var location = await locationDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(location);
        }
    }
}
