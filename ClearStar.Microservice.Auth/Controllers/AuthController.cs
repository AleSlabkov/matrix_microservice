using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Service;
using ClearStar.Microservice.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ClearStar.Microservice.Auth.RavenConfiguration;
using ClearStar.Microservice.Auth.Repositories;

namespace ClearStar.Microservice.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController()
        {
            var ravenSettings = new RavenSettings { Url = "http://127.0.0.1:8080", Database = "MTX" };
            var userRepository = new UserRepository(new DocumentStoreHolder(ravenSettings));
            authService = new AuthService(userRepository);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginInfo userLoginInfo)
        {
            try
            {
                if (userLoginInfo == null)
                    return BadRequest();

                var validateResults = await authService.Login(userLoginInfo.UserName, userLoginInfo.Password);

                if (validateResults.Result != Result.Ok)
                    return BadRequest(validateResults.Result);

                return Ok(validateResults.AccessToken);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
    }
}
