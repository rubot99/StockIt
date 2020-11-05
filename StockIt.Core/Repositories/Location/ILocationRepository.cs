using System.Collections.Generic;

namespace StockIt.Core.Repositories.Location
{
    public interface ILocationRepository : IRepository<Location>
    {
        List<Location> SearchByName(string name);
    }
}
