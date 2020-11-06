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

        public LocationDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Location> AddAsync(Location t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> GetAllAsync(string tenant)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ConstantsClass.Url + "/" + $"location/tenant/{tenant}");
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
