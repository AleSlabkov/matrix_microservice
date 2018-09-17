using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Data
{
    public class LoginResult
    {
        public Result Result { get; set; }
        public string AccessToken { get; set; }
    }

    public enum Result
    {
        Ok,
        Expired,
        BadCredentials,
        Inactive,
    }
}
