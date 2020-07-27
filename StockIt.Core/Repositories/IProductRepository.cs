using StockIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {       
        Product GetByName(string name, string tenant);

        List<Product> SearchById(string id);
        List<Product> SearchByCategory(string category);
        List<Product> SearchByLocation(string location);
        List<Product> SearchByName(string name);
    }

    public interface IRepository<T>
    {
        T AddAsync(T t, string tenant);
        bool DeleteAsync(T t, string tenant);
        T UpdateAsync(T t, string tenant);
    }
}
