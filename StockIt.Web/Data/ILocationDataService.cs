using StockIt.Core.Repositories.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public interface ILocationDataService : IDataService<Location>
    {
        Task<List<Location>> GetAllAsync(string tenant);
    }
}
