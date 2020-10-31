﻿using StockIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchByTags(List<string> tags);
        List<Product> SearchByLocation(string location);
        List<Product> SearchByName(string name);
    }
}
