﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StockIt.Core.Models;
using StockIt.Core.Repositories;

namespace StockIt.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProductRepository productRepository;

        public ProductController(ILogger logger, IProductRepository productRepository)
        {
            this.logger = logger;
            this.productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var created = productRepository.Add(product);
            return Ok(created.Id);

        }

        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            var updated = productRepository.Update(product);
            return Ok(updated);
        }

        [HttpGet("/name/{name}")]
        public IActionResult Search([FromRoute] string name)
        {
            var products = productRepository.SearchByName(name);
            return Ok(products);
        }
    }
}
