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

            var money = new List<Money>
            {
                new Money { Denominator = 100, RemainingPieces = 100 },
                new Money { Denominator = 500, RemainingPieces = 200 }
            };
            money.ForEach(m => context.Money.Add(m));
            context.SaveChanges();

            var transactions = new List<Transaction>();

            foreach (var account in accounts)
            {
                DateTime date = DateTime.Now;
                double bal = account.Balance;
                string type = "";

                for (int i = 0; i < 30; i++)
                {
                    double amount = rnd.Next(1, 20 + 1) * 100;

                    if (rnd.Next(0, 2) == 0)
                    {
                        type = "Uttag";
                    }
                    else
                    {
                        type = "Insättning";
                    }

                    date = date.AddDays(rnd.Next(-5, 1));

                    transactions.Add(new Transaction { TransactionTime = date, TransactionType = type, Balance = bal, Amount = amount, Account = account });

                    if (type == "Uttag") bal = bal + amount;
                    else bal = bal - amount;
                }
            }
            transactions.ForEach(t => context.Transactions.Add(t));
            context.SaveChanges();
        }


        //            [Display(Name = "Tid")]
        //public DateTime TransactionTime { get; set; }
        //[Display(Name = "Typ av transaktion")]
        //public string TransactionType { get; set; }
        //[Display(Name = "Saldo")]
        //public double Balance { get; set; }
        //[Display(Name = "Belopp")]
        //public double Amount { get; set; }

        //public BankAccount Account { get; set; }
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

