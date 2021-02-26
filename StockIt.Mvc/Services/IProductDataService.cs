using StockIt.Core.Repositories.Product;
using StockIt.Mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface IProductDataService : IDataService<Product>
    {
        Task<List<Product>> GetAllAsync(string tenant);

        Task<Product> GetAsync(string id, string tenant);

        Task<Product> GetBarcodeAsync(string barcode, string tenant);

        Task<bool> UpdateStockAsync(List<ProductStock> productStocks, string tenant);
    }
}
