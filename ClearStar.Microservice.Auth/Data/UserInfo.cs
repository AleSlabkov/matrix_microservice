using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Data
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IList<Guid> Roles { get; set; }
        public IDictionary<Guid,string> Claims { get; set; }
    }
}
