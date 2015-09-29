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
            Random rnd = new Random();
            PasswordHasher passwordHasher = new PasswordHasher();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "321564863", Email = "321564863", PasswordHash = passwordHasher.HashPassword("1234")},
                new ApplicationUser { UserName = "654684654", Email = "654684654", PasswordHash = passwordHasher.HashPassword("1234")}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();


            var accounts = new List<BankAccount>();

            foreach (var user in users)
            {
                accounts.Add(new BankAccount { AccountNumber = rnd.Next(152354853, 356845242), Name = "Sparkonto", User = user, Balance = rnd.Next(25000, 30000) });
                accounts.Add(new BankAccount { AccountNumber = rnd.Next(152354853, 356845242), Name = "Lönekonto", User = user, Balance = rnd.Next(25000, 30000) });
            }
            accounts.ForEach(a => context.Accounts.Add(a));
            context.SaveChanges();

            var receipts = new List<Receipt>();
            {
                new Receipt { Length = 13.2, Active = false };
                new Receipt { Length = 8.5, Active = false };
                new Receipt { Length = 7.1, Active = false };
                new Receipt { Length = 6.7, Active = true };
            }

                 

        //var courses = new List<Course>
        //{
        //    new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3, },
        //    new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, },
        //    new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
        //    new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, },
        //    new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4, },
        //    new Course {CourseID = 2021, Title = "Composition",    Credits = 3, },
        //    new Course {CourseID = 2042, Title = "Literature",     Credits = 4, }
        //};
        //courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
        //context.SaveChanges();



    }
    }

}