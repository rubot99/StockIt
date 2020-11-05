using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockIt.Core.Repositories.Tenant
{
    public class TenantRepository : ITenantRepository
    {
        public Tenant Add(Tenant t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(Tenant t)
        {
            throw new NotImplementedException();
        }

        public Tenant Get(string id, string tenant)
        {
            throw new NotImplementedException();
        }

        public List<Tenant> GetAll(string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<Tenant>().ToList();
            }
        }

        public Tenant Update(Tenant t)
        {
            throw new NotImplementedException();
        }
    }
}
