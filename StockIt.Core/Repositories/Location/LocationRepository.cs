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
                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(Location t)
        {
            throw new NotImplementedException();
        }

        public Location Get(string id, string tenant)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetAll(string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<Location>().ToList();
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
