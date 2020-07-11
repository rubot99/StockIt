using StockIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockIt.Core.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> store;

        public MockProductRepository()
        {
            store = new List<Product>();
        }

        public Product AddAsync(Product product, string tenant)
        {
            bool result = false;

            if (!store.Exists(x => x.Id.Equals(product.Id, StringComparison.OrdinalIgnoreCase)
             && x.Tenant.Equals(product.Tenant, StringComparison.OrdinalIgnoreCase)))
            {
                store.Add(product);
                result = true;
            }

            return result == true ? product : null;
        }

        public bool DeleteAsync(Product product, string tenant)
        {
            bool result = false;

            if(store.Exists(x => x.Id.Equals(product.Id, StringComparison.OrdinalIgnoreCase) 
            && x.Tenant.Equals(product.Tenant, StringComparison.OrdinalIgnoreCase)))
            {
                store.Remove(product);
                result = true;
            }

            return result;
        }

        public Product GetByName(string name, string tenant)
        {
            return store.FirstOrDefault<Product>(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
             && x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase));
        }

        public Product UpdateAsync(Product product, string tenant)
        {
            bool result = false;

            if (!store.Exists(x => x.Id.Equals(product.Id, StringComparison.OrdinalIgnoreCase)
             && x.Tenant.Equals(product.Tenant, StringComparison.OrdinalIgnoreCase)))
            {
                var existingProduct = store.FirstOrDefault<Product>(x => x.Id.Equals(product.Id, StringComparison.OrdinalIgnoreCase)
             && x.Tenant.Equals(product.Tenant, StringComparison.OrdinalIgnoreCase));

                existingProduct = product;
                result = true;
            }

            return result == true ? product : null;
        }
    }
}
