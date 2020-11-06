using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockIt.Core.Repositories.Location;
using StockIt.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class LocationDataService : ILocationDataService
    {
        private readonly HttpClient httpClient;
        private readonly Url url;

        public LocationDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.url = new Url($"{ConstantsClass.Url}/location");
        }

        public Task<Location> AddAsync(Location t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url.ToString()}/id/{id}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Location>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url.ToString()}/tenant/{tenant}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var locations = new List<Location>();

            if (response.IsSuccessStatusCode)
            {
                locations = JsonConvert.DeserializeObject<List<Location>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return locations;
        }
    }
}
