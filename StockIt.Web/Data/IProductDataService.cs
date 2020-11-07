using StockIt.Core.Repositories.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public interface IProductDataService : IDataService<Product>
    { 
        Task<List<Product>> GetAllAsync(string tenant);

        Task<Product> GetAsync(string id, string tenant);
    }
}
