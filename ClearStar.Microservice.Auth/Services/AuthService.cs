using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Entities;
using ClearStar.Microservice.Auth.Services;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using ClearStar.Microservice.Auth.Repositories;

namespace ClearStar.Microservice.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //move to config 
        private const string secret = "veryVerySecretKey";

        public User GetFakeUser()
        {
            var user = new User();

            user.UserName = "aslabkov";
            user.PasswordHash = "thisisthepassword";
            user.Email = "alejandro.slabkov@endava.com";
            user.Roles = new List<Role>() { new Role() { Name = "ADMIN" }, new Role() { Name = "SUPER ADMIN" } };
            user.Claims = new List<Claim>() { new Claim() { Name = "BOID", Value = "593" }, new Claim() { Name = "CUSTOM", Value = "this is the value" } };

            return user;
        }

        public string GetToken(User user)
        {
            return BuildToken(user);
        }

        public User ReadToken(string token)
        {
            var tokenS = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(tokenS.Payload.SerializeToJson());

            return user;

        }

        private string BuildToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credentials);

            var payload = new JwtPayload
            {
               { "UserName", user.UserName},
               { "Email", user.Email},
               { "Roles", user.Roles },
               { "Claims", user.Claims}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);

        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var user = _userRepository.GetByUserName(username);

            if (user == null) return new LoginResult() { Result = Result.BadCredentials };

            if (user.UserName == username && user.PasswordHash == password)
                return new LoginResult() { Result = Result.Ok, AccessToken = GetToken(user) };

            return new LoginResult() { Result = Result.BadCredentials };
        }


    }
}
