using StockIt.Core.Repositories.Products;
using StockIt.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public interface IProductDataService : IDataService<Product>
    { 
        Task<List<Product>> GetAllAsync(string tenant);

        Task<Product> GetAsync(string id, string tenant);

        Task<Product> GetBarcodeAsync(string barcode, string tenant);

        Task<bool> UpdateStockAsync(List<ProductStock> productStocks, string tenant);
    }
}
