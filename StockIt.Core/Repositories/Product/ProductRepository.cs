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
                t.Id = string.Empty;

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

        public Product GetBarcode(string barcode, string tenant)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<Product>()
                    .Where(x => x.Id.Equals(barcode, StringComparison.OrdinalIgnoreCase)
                    && x.Tenant.Equals(tenant, StringComparison.OrdinalIgnoreCase));

                return query.FirstOrDefault();
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
                var existingProduct = session.Load<Product>(t.Id);

                if (existingProduct != null)
                {
                    existingProduct.Name = t.Name;
                    existingProduct.StoreItems = t.StoreItems;
                    existingProduct.Tags = t.Tags;
                    existingProduct.Updated = DateTime.Now;
                    existingProduct.AlertQuantity = t.AlertQuantity;
                    existingProduct.Barcode = t.Barcode;
                    existingProduct.Description = t.Description;

                    decimal totalQuantity = 0;
                    existingProduct.StoreItems.ForEach(x =>
                    {
                        totalQuantity = totalQuantity + x.Quantity;
                    });

                    existingProduct.TotalQuantity = totalQuantity;

                    session.SaveChanges();

                    return existingProduct;
                }

                return null;
            }
        }
    }
}
