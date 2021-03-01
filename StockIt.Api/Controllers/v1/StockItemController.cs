using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockIt.Core.Repositories.Stock;
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
        [HttpGet("stockactions")]
        public IActionResult GetStockActions()
        {
            return Ok(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(StockAction.AddToStock.ToString(),StockAction.AddToStock.ToString()),
                new KeyValuePair<string, string>(StockAction.RemoveFromStock.ToString(),StockAction.RemoveFromStock.ToString()),
            });
        }
    }
}
