using Microsoft.Extensions.DependencyInjection;
using StockIt.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockIt.Core.Extensions
{
    public static class ServiceExtension
    {
        public static void AddMockedServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, MockProductRepository>();
        }
    }
}
