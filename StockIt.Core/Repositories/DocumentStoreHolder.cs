using Raven.Client.Documents;
using System;
using System.Security.Cryptography.X509Certificates;

namespace StockIt.Core.Repositories
{
    public class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> _store = new Lazy<IDocumentStore>(CreateDocumentStore);

        private static IDocumentStore CreateDocumentStore()
        {
            string serverURL = "https://a.faraday.development.run/";
            string databaseName = "stockit";

            IDocumentStore documentStore = new DocumentStore
            {
                Urls = new[] { serverURL },
                Database = databaseName,
                Certificate = new X509Certificate2(@"C:\Users\reube\OneDrive\Documents\Certs\stockitweb\stockitweb.pfx"),
            };

            documentStore.Initialize();
            return documentStore;
        }

        public static IDocumentStore Store
        {
            get { return _store.Value; }
        }
    }
}
