using ClearStar.Microservice.Auth.Entities;
using ClearStar.Microservice.Auth.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace ClearStar.Microservice.Auth.Test
{
    public class AuthServiceTest
    {
        [Fact]
        public void GenerateToken()
        {
            var auth = new AuthService();

            var user = new User();

            user.UserName = "aslabkov";
            user.Email = "alejandro.slabkov@endava.com";
            user.Roles = new List<Role>() { new Role() { Name = "ADMIN" }, new Role() { Name = "SUPER ADMIN" } };
            user.Claims = new List<Claim>() { new Claim() { Name = "BOID", Value = "593" }, new Claim() { Name = "CUSTOM", Value = "this is the value" } };

            var token = auth.GetToken(user);

            var userDeserialize = auth.ReadToken(token);

            Assert.Equal(user.UserName, userDeserialize.UserName);
            Assert.Equal(user.Email, userDeserialize.Email);

            Assert.Equal(user.Claims.Count, userDeserialize.Claims.Count);
            Assert.Equal(user.Roles.Count, userDeserialize.Roles.Count);

        }
    }
}
