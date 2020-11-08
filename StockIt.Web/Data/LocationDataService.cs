using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockIt.Core.Repositories.Location;
using StockIt.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class LocationDataService : ILocationDataService
    {
        private readonly HttpClient httpClient;
        private readonly string url;

        public LocationDataService(HttpClient httpClient, IOptions<StockApiConfig> stockApiConfig)
        {
            this.httpClient = httpClient;

            if (stockApiConfig.Value != null)
            {
                this.url = $"{stockApiConfig.Value?.Url}/location";
            }
        }

        public async Task<Location> AddAsync(Location t)
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

        public async Task<List<Location>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var locations = new List<Location>();

            if (response.IsSuccessStatusCode)
            {
                locations = JsonConvert.DeserializeObject<List<Location>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return locations;
        }

        public async Task<Location> GetAsync(string id, string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/id/{id}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var location = new Location();

            if (response.IsSuccessStatusCode)
            {
                location = JsonConvert.DeserializeObject<Location>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return location;
        }

        public async Task<bool> UpdateAsync(Location t)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{url}");
            request.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
