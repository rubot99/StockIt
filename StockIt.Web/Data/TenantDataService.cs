﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockIt.Core.Repositories.Tenants;
using StockIt.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class TenantDataService : ITenantDataService
    {
        private readonly HttpClient httpClient;
        private readonly string url;
        
        public TenantDataService(HttpClient httpClient, IOptions<StockApiConfig> stockApiConfig)
        {
            this.httpClient = httpClient;

            if (stockApiConfig.Value != null)
            {
                this.url = $"{stockApiConfig.Value?.Url}/location";
            }
        }

        public Task<Tenant> AddAsync(Tenant t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/id/{id}");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Tenant>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var tenants = new List<Tenant>();

            if (response.IsSuccessStatusCode)
            {
                tenants = JsonConvert.DeserializeObject<List<Tenant>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return tenants;
        }

        public Task<bool> UpdateAsync(Tenant t)
        {
            throw new NotImplementedException();
        }
    }
}
