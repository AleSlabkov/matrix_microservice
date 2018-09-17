using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Entities;
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
        string GetToken(User user);
       

    }
}
