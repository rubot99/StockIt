using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockIt.Core.Repositories.StockItems;
using StockIt.Core.Repositories.Tenants;
using StockIt.Mvc.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        public async Task<StockItem> AddAsync(StockItem t)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}");
            request.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return t;
        }

        public Task<bool> DeleteAsync(string id, string tenant)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StockItem>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var stockItems = new List<StockItem>();

            if (response.IsSuccessStatusCode)
            {
                stockItems = JsonConvert.DeserializeObject<List<StockItem>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return stockItems;
        }

        public async Task<StockItem> GetAsync(string id, string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/id/{id}tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var stockItem = new StockItem();

            if (response.IsSuccessStatusCode)
            {
                stockItem = JsonConvert.DeserializeObject<StockItem>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return stockItem;
        }

        //////public async Task<List<KeyValuePair<string, string>>> GetStockActionsAsync()
        //////{
        //////    var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/stockactions");
        //////    var response = await httpClient.SendAsync(request).ConfigureAwait(false);
        //////    var stckActions = new List<KeyValuePair<string, string>>();

        //////    if (response.IsSuccessStatusCode)
        //////    {
        //////        stckActions = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        //////    }

        //////    return stckActions;
        //////}

        public Task<bool> UpdateAsync(StockItem t)
        {
            throw new NotImplementedException();
        }
    }
}
