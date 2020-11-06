using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockIt.Core.Repositories.Location
{
    public class LocationRepository : ILocationRepository
    {
        public Location Add(Location t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                t.Id = string.Empty;

                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(Location t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Delete(t.Id);
                session.SaveChanges();

                return true;
            }
        }

        public Location Get(string id, string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Location>()
                    .Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)
                    && x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase));

                return query.FirstOrDefault();
            }
        }

        public List<Location> GetAll(string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<Location>()
                    .Where(x => x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        public List<Location> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Location Update(Location t)
        {
            throw new NotImplementedException();
        }

        List<Location> ILocationRepository.SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
