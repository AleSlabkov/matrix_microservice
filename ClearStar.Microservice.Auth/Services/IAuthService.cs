using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Entities;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Services
{
    interface IAuthService
    {
        Task<LoginResult> Login(string username, string password);
        string GetToken(User user);
    }
}
