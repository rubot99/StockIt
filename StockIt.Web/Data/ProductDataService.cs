using Newtonsoft.Json;
using StockIt.Core.Repositories.Product;
using StockIt.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly HttpClient httpClient;

        public ProductDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Product> AddAsync(Product t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ConstantsClass.Url + "/" + $"product/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var locations = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                locations = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return locations;
        }
    }
}
