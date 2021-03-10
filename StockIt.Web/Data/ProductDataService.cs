using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockIt.Core.Repositories.Products;
using StockIt.Web.Common;
using StockIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly HttpClient httpClient;
        private readonly string url;

        public ProductDataService(HttpClient httpClient, IOptions<StockApiConfig> stockApiConfig)
        {
            this.httpClient = httpClient;

            if (stockApiConfig.Value != null)
            {
                this.url = $"{stockApiConfig.Value?.Url}/product";
            }
        }

        public async Task<Product> AddAsync(Product t)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}");
            request.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return t;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/id/{id}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Product>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return products.OrderBy(x => x.Created).ToList();
        }

        public async Task<Product> GetAsync(string id, string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/id/{id}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var product = new Product();

            if (response.IsSuccessStatusCode)
            {
                product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return product;
        }

        public async Task<Product> GetBarcodeAsync(string barcode, string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/barcode/{barcode}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var product = new Product();

            if (response.IsSuccessStatusCode)
            {
                product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return product;
        }

        public async Task<bool> UpdateAsync(Product t)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{url}");
            request.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateStockAsync(List<ProductStock> productStocks, string tenant)
        {
            var result = false;

            foreach (var productStock in productStocks)
            {
                var product = await GetBarcodeAsync(productStock.Barcode, tenant);

                productStock.RemoveItems.ForEach(x => {
                    var storeItem = product.StoreItems.FirstOrDefault(y => y.LocationId.Equals(x.LocationId, StringComparison.OrdinalIgnoreCase));
                    if(storeItem != null)
                    {
                        storeItem.Quantity = storeItem.Quantity - x.Quantity;
                    }
                });

                productStock.AddItems.ForEach(x => {
                    var storeItem = product.StoreItems.FirstOrDefault(y => y.LocationId.Equals(x.LocationId, StringComparison.OrdinalIgnoreCase));
                    if (storeItem != null)
                    {
                        storeItem.Quantity = storeItem.Quantity + x.Quantity;
                    }
                });

                await UpdateAsync(product).ConfigureAwait(false);
            }

            return result;
        }
    }
}
