using Newtonsoft.Json;
using StockIt.Core.Repositories.Product;
using StockIt.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly HttpClient httpClient;
        private readonly string url;

        public ProductDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.url = $"{ConstantsClass.Url}/product";
        }

        public Task<Product> AddAsync(Product t)
        {
            throw new NotImplementedException();
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
            var locations = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                locations = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return locations;
        }

        Task<bool> IDataService<Product>.DeleteAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/id/{id}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }
    }
}
