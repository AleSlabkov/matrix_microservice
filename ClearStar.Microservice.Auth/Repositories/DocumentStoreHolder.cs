using ClearStar.Microservice.Auth.Indexes;
using ClearStar.Microservice.Auth.RavenConfiguration;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;


namespace ClearStar.Microservice.Auth.Repositories
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }

    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(RavenSettings ravenSettings)
        {
            Store = new DocumentStore
            {
                Urls = new[] { ravenSettings.Url },
                Database = ravenSettings.Database
            };

            Store.Initialize();

            // Create indexes
            IndexCreation.CreateIndexes(typeof(Users_ByUsername).Assembly, Store);
        }

        public IDocumentStore Store { get; }

        #region Nothing to see here!
    }
    #endregion

}