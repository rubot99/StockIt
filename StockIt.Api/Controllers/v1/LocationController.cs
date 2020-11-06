using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StockIt.Core.Repositories.Location;

namespace StockIt.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ILocationRepository locationRepository;

        public LocationController(ILogger logger, ILocationRepository locationRepository)
        {
            this.logger = logger;
            this.locationRepository = locationRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Location location)
        {
            var created = locationRepository.Add(location);
            return Ok(created.Id);
        }

        [HttpGet("tenant/{tenant}")]
        public IActionResult GetAll([FromRoute] string tenant)
        {
            var locations = locationRepository.GetAll(tenant);
            return Ok(locations);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(string id)
        {
            var tenant = locationRepository.Delete(
                new Location
                {
                    Id = id
                });

            return Ok();
        }
    }
}
