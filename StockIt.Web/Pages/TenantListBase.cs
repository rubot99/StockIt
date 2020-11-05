using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class TenantListBase : ComponentBase
    {
        protected List<Tenant> tenants;
    }
}
