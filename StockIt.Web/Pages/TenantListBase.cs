using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Tenant;
using StockIt.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class TenantListBase : ComponentBase
    {
        protected List<Tenant> tenants;

        [Inject]
        public ITenantDataService tenantDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            tenants = await tenantDataService.GetAllAsync().ConfigureAwait(false);
        }
    }
}
