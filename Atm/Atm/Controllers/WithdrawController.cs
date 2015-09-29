using Atm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace Atm.Controllers
{
    public class WithdrawController : Controller
    {
        // GET: Withdraw
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Withdraw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Withdraw/Create
        [HttpPost]
        public ActionResult Create(WithdrawViewModel model)
        {
            using (ApplicationDbContext dataContext = new ApplicationDbContext())
            {
                using (var trans = dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        BankAccount account = dataContext.Accounts.Where(a => a.WithdrawAccount == true && a.User.UserName == User.Identity.Name).First();

                        //If account balance is enough
                        if (account.Balance > model.Amount)
                        {
                            account.Balance -= model.Amount;
                            dataContext.SaveChanges();
                            trans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Console.WriteLine(ex.InnerException);
                    }

                }
            }
            //Return to startpage and automatically log out
            return RedirectToAction("Index", "Home");
        }
    }
}
