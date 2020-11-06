using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories.Product
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(string id, string tenant);
        List<Product> GetAll(string tenant);
        List<Product> SearchByTags(List<string> tags);
        List<Product> SearchByLocation(string location);
        List<Product> SearchByName(string name);
    }
}
