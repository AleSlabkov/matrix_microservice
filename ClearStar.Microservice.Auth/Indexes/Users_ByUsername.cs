using System.Linq;
using ClearStar.Microservice.Auth.Entities;
using Raven.Client.Documents.Indexes;

namespace ClearStar.Microservice.Auth.Indexes
{
    public class Users_ByUsername
    {
        public Users_ByUsername()
        {
            IndexDefinitionBuilder<User> builder = new IndexDefinitionBuilder<User>();

            builder.Map = users =>
                from user in users
                select new
                {
                    user.UserName
                };
        }
    }
}
