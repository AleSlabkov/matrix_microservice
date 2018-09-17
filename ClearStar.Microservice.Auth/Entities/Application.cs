using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Entities
{
    public class Application : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Claim> Claims { get; set; }
    }
}
