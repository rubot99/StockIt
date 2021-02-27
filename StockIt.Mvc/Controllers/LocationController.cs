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
    }
}
}
