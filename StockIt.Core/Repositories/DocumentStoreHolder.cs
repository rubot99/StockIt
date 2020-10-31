using Raven.Client.Documents;
using System;

namespace StockIt.Core.Repositories
{
    public class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> _store = new Lazy<IDocumentStore>(CreateDocumentStore);

        private static IDocumentStore CreateDocumentStore()
        {
            string serverURL = "http://localhost:8080";
            string databaseName = "stockit";

            IDocumentStore documentStore = new DocumentStore
            {
                Urls = new[] { serverURL },
                Database = databaseName
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
