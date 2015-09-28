using Atm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Atm.DAL
{

    public class AtmInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "321564863", PasswordHash = passwordHasher.HashPassword("1234")},
                new ApplicationUser { UserName = "654684654", PasswordHash = passwordHasher.HashPassword("1234")}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

        }
    }

}