using StockIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {       
        Product GetByName(string name, string tenant);        
    }

    public interface IRepository<T>
    {
        T AddAsync(T t, string tenant);
        bool DeleteAsync(T t, string tenant);
        T UpdateAsync(T t, string tenant);
    }
}
