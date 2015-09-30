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
                new ApplicationUser { UserName = "321564863", Email = "321564863", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = passwordHasher.HashPassword("1234")},
                new ApplicationUser { UserName = "654684654", Email = "654684654", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = passwordHasher.HashPassword("1234")}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();


            var accounts = new List<BankAccount>();

            foreach (var user in users)
            {
                accounts.Add(new BankAccount { AccountNumber = rnd.Next(152354853, 356845242), Name = "Sparkonto", User = user, Balance = rnd.Next(25000, 30000), WithdrawAccount = true });
                accounts.Add(new BankAccount { AccountNumber = rnd.Next(152354853, 356845242), Name = "Lönekonto", User = user, Balance = rnd.Next(25000, 30000)});
            }
            accounts.ForEach(a => context.Accounts.Add(a));
            context.SaveChanges();

            var receipts = new List<Receipt>()
            {
                new Receipt { Length = 13.2, Active = false },
                new Receipt { Length = 8.5, Active = false },
                new Receipt { Length = 7.1, Active = false },
                new Receipt { Length = 6.7, Active = true }
            };
            receipts.ForEach(r => context.Receipts.Add(r));
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


            var clickLogs = new List<ClickLog>();
            foreach (var user in users)
            {

                clickLogs.Add(new ClickLog { Time = new DateTime(2015, rnd.Next(1, 9), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(1, 59), rnd.Next(1, 59), rnd.Next(1, 999)), Amount = 1000, EventType = "Withdrawl", TurnOut = "Succeded", UserName = user.UserName });
                clickLogs.Add(new ClickLog { Time = new DateTime(2015, rnd.Next(1, 9), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(1, 59), rnd.Next(1, 59), rnd.Next(1, 999)), Amount = 0, EventType = "Receipt", TurnOut = "Denied", UserName = user.UserName });
            }
            clickLogs.ForEach(c => context.ClickLogs.Add(c));
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

