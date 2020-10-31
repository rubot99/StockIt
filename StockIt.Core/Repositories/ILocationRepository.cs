using StockIt.Core.Models;
using System.Collections.Generic;

namespace StockIt.Core.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        List<Product> SearchByName(string name);
    }
}
