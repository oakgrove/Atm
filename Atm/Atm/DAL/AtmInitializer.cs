﻿using Atm.Models;
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
                new ApplicationUser { UserName = "321564863", Email = "321564863", PasswordHash = passwordHasher.HashPassword("1234")},
                new ApplicationUser { UserName = "654684654", Email = "654684654", PasswordHash = passwordHasher.HashPassword("1234")}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

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