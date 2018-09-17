using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClearStar.Microservice.Auth.Controllers
{
    public class AuthController
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        public void Post([FromBody] UserInfo user)
        {
            _userService.Create(user);
        }
    }
}
