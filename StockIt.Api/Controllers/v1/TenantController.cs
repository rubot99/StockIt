using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StockIt.Core.Repositories.Tenant;

namespace StockIt.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ITenantRepository tenantRepository;

        public TenantController(ILogger logger, ITenantRepository tenantRepository)
        {
            this.logger = logger;
            this.tenantRepository = tenantRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Tenant tenant)
        {
            var created = tenantRepository.Add(tenant);
            return Ok(created.Id);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var tenants = tenantRepository.GetAll();
            return Ok(tenants);
        }

        [HttpGet("id/{id}")]
        public IActionResult Get(string id)
        {
            var tenant = tenantRepository.Get(id);
            return Ok(tenant);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(string id)
        {
            var tenant = tenantRepository.Delete(
                new Tenant
                {
                    Id = id
                });

            return Ok();
        }
    }
}
