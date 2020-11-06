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
                t.Id = string.Empty;

                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(Tenant t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Delete(t.Id);
                session.SaveChanges();

                return true;
            }
        }

        public Tenant Get(string id)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Tenant>()
                    .Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

                return query.FirstOrDefault();
            }
        }

        public List<Tenant> GetAll()
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
