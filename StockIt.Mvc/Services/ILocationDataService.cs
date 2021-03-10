using StockIt.Core.Repositories.Locations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface ILocationDataService : IDataService<Location>
    {
        Task<List<Location>> GetAllAsync(string tenant);
        Task<Location> GetAsync(string id, string tenant);
    }
}
