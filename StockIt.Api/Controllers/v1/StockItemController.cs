using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockIt.Core.Repositories.StockItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemRepository stockItemRepository;

        public StockItemController(IStockItemRepository stockItemRepository)
        {
            this.stockItemRepository = stockItemRepository;
        }

        [HttpPost]
        public IActionResult AddStockItem([FromBody] StockItem stockItem)
        {
            return Ok(stockItemRepository.Add(stockItem));
        }

        [HttpGet("tenant/{tenant}")]
        public IActionResult GetAll([FromRoute] string tenant)
        {
            var stockItems = stockItemRepository.GetAll(tenant);
            return Ok(stockItems);
        }
    }
}
