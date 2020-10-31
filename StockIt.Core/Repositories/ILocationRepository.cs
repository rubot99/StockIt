using StockIt.Core.Models;
using System.Collections.Generic;

namespace StockIt.Core.Repositories
{
    public interface ILocationRepository : IRepository<LocationTypes>
    {
        List<Product> SearchByName(string name);
    }
}
