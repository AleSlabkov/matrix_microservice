using ClearStar.Microservice.Auth.Entities;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace ClearStar.Microservice.Auth.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IDocumentStore _store;

        public UserRepository()
        {
            using (IDocumentStore store = new DocumentStore
            {
                Urls = new[]                        // URL to the Server,
                {                                   // or list of URLs 
                    "http://live-test.ravendb.net"  // to all Cluster Servers (Nodes)
                },
                Database = "Northwind",             // Default database that DocumentStore will interact with
                Conventions = { }                   // DocumentStore customizations
            })
            {
                _store = store.Initialize();                 // Each DocumentStore needs to be initialized before use.
                // This process establishes the connection with the Server
                // and downloads various configurations
                // e.g. cluster topology or client configuration
            }

        }

        public void Create(User user)
        {
            using (IDocumentSession session = _store.OpenSession())  // Open a session for a default 'Database'
            {
                session.Store(user);
                session.SaveChanges();
            }
        }
    }
}
