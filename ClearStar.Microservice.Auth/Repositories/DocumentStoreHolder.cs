using System.Collections.Generic;
using ClearStar.Microservice.Auth.Indexes;
using ClearStar.Microservice.Auth.RavenConfiguration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;


namespace ClearStar.Microservice.Auth.Repositories
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }

    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private readonly ILogger<DocumentStoreHolder> _logger;

        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings, ILogger<DocumentStoreHolder> logger)
        {
            this._logger = logger;
            var settings = ravenSettings.Value;

            Store = new DocumentStore()
            {
                Urls = new[] { settings.Url },
                Database = settings.Database
            };

            Store.Initialize();

            this._logger.LogInformation("🌟  Initialized RavenDB document store for {0} at {1}",
                settings.Database, settings.Url);

            // Create indexes
            IndexCreation.CreateIndexes(
                typeof(Users_ByUsername).Assembly, Store);
        }

        public IDocumentStore Store { get; }

        #region Nothing to see here!
    }
    #endregion

}