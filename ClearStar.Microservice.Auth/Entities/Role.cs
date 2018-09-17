using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.Entities
{
    public class Role : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
