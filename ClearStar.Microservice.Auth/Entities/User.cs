using System;
using System.Collections.Generic;


namespace ClearStar.Microservice.Auth.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Claim> Claims { get; set; }
    }
}
