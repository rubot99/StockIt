using Microsoft.Extensions.Logging;
using StockIt.Core.Repositories.Tenant;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public class TenantDataService : ITenantDataService
    {
        private readonly HttpClient httpClient;

        public TenantDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Tenant> AddAsync(Tenant t)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tenant>> GetAllAsync(string tenant)
        {
            throw new NotImplementedException();
        }
    }
}
