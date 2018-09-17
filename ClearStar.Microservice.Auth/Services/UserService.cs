using System.Collections.Generic;
using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Entities;
using ClearStar.Microservice.Auth.Repositories;

namespace ClearStar.Microservice.Auth.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserInfo userInfo)
        {
            var user = new User
            {
                Email = userInfo.Email,
                UserName = userInfo.UserName
            };

            _userRepository.Create(user);
        }
    }
}
