using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockIt.Core.Repositories.Tenants;
using StockIt.Mvc.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public class StockItemDataService : IStockItemDataService
    {
        private readonly HttpClient httpClient;
        private readonly string url;

        public StockItemDataService(HttpClient httpClient, IOptions<StockApiConfig> stockApiConfig)
        {
            this.httpClient = httpClient;

            if (stockApiConfig.Value != null)
            {
                url = $"{stockApiConfig.Value?.Url}/stockitem";
            }
        }
        public Task<Tenant> AddAsync(Tenant t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id, string tenant)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KeyValuePair<string, string>>> GetStockActionsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/stockactions");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var stckActions = new List<KeyValuePair<string, string>>();

            if (response.IsSuccessStatusCode)
            {
                stckActions = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return stckActions;
        }

        public Task<bool> UpdateAsync(Tenant t)
        {
            throw new NotImplementedException();
        }
    }
}
