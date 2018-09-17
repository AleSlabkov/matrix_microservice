using ClearStar.Microservice.Auth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Services
{
    interface IAuthService
    {
        Task<LoginResult> Login(string username, string password);
        Task CreateUser(UserInfo user);
       

    }
}
