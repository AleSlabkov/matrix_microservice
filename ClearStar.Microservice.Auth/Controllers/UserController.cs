using System;
using System.Threading.Tasks;
using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Entities;
using ClearStar.Microservice.Auth.RavenConfiguration;
using ClearStar.Microservice.Auth.Repositories;
using ClearStar.Microservice.Auth.Service;
using ClearStar.Microservice.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClearStar.Microservice.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController()
        {
            var ravenSettings = new RavenSettings {Url = "http://127.0.0.1:8080", Database = "MTX"};
            var userRepository = new UserRepository(new DocumentStoreHolder(ravenSettings));
            _userService = new UserService(userRepository);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserInfo userInfo)
        {
            try
            {
                if (userInfo == null)
                    return BadRequest();

                _userService.Create(userInfo);

                return Ok("Create OK. Please login");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
    }
}