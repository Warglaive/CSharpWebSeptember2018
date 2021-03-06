﻿using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Torshia.Data;
using Torshia.Models;
using Torshia.Models.Enums;
using Torshia.Web.Services.Contracts;

namespace Torshia.Web.Services
{
    public class UsersService : IUsersService
    {
        private readonly TorshiaContext context;

        public UsersService(TorshiaContext context)
        {
            this.context = context;
        }

        public void RegisterUser(string username, string password, string email)
        {
            var role = EnumerableExtensions.Any(this.context.Users) ? Roles.User : Roles.Admin;

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role
            };
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool UserExistsByUsernameAndPassword(string username, string password) =>
            this.context.Users.Any(x => x.Username == username && x.Password == password);
    }
}