using StockIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories
{
    public interface IProductRepository
    {
        Product AddAsync(Product product, string tenant);
        bool DeleteAsync(Product product, string tenant);
        Product UpdateAsync(Product product, string tenant);
        Product GetByName(string name, string tenant);        
    }
}
