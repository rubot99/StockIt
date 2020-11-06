using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockIt.Core.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        public Product Add(Product t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                t.Id = null;

                session.Store(t);

                session.SaveChanges();

                return t;
            }
        }

        public bool Delete(Product t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Delete(t.Id);
                session.SaveChanges();

                return true;
            }
        }

        public Product Get(string id, string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Product>()
                    .Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)
                    && x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase));

                return query.FirstOrDefault();
            }
        }

        public List<Product> GetAll(string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<Product>()
                    .Where(x => x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        public List<Product> SearchByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> SearchById(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> SearchByLocation(string location)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> SearchByName(string name)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Product>()
                    .Search(x => x.Name, name)
                    .ToList();

                return query;
            }
        }

        public List<Product> SearchByTags(List<string> tags)
        {
            throw new System.NotImplementedException();
        }

        public Product Update(Product t)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Product>()
                    .Where(x => x.Id == t.Id);

                var existingProduct = query.FirstOrDefault();

                if (existingProduct == null)
                {
                    existingProduct = t;
                    session.SaveChanges();

                    return existingProduct;
                }

                return null;
            }
        }
    }
}
