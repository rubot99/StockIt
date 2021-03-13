using Raven.Client.Documents.Session;
using StockIt.Core.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockIt.Core.Repositories.StockItems
{
    public class StockItemRepository : IStockItemRepository
    {
        public StockItem Add(StockItem t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                t.Id = string.Empty;

                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(StockItem t)
        {
            throw new NotImplementedException();
        }

        public List<StockItem> GetAll(string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<StockItem>()
                    .Where(x => x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        public StockItem Update(StockItem t)
        {
            throw new NotImplementedException();
        }
    }
}