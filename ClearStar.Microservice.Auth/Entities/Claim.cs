using System;

namespace ClearStar.Microservice.Auth.Entities
{
    public class Claim : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid ApplicationId { get; set; }
        
    }
}
