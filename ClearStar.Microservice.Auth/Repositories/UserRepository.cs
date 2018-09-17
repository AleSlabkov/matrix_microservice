using System.Threading.Tasks;
using ClearStar.Microservice.Auth.Entities;
using Raven.Client.Documents;

namespace ClearStar.Microservice.Auth.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IDocumentStore _store;

        public UserRepository(IDocumentStoreHolder storeHolder)
        {
            _store = storeHolder.Store;
        }

        public async Task Create(User user)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(user);
                await session.SaveChangesAsync();
            }
        }
    }
}
