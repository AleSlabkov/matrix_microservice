using ClearStar.Microservice.Auth.Data;
using ClearStar.Microservice.Auth.Service;
using ClearStar.Microservice.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController()
        {
            authService = new AuthService();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserInfo user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var validateResults = await authService.Login(user.UserName, user.Password);

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
