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
            using (ApplicationDbContext dataContext = new ApplicationDbContext())
            {
                using (var trans = dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        BankAccount account = dataContext.Accounts.Where(a => a.WithdrawAccount == true && a.User.UserName == User.Identity.Name).First();
                        double maxvalue = (account.Balance < 5000 ? (account.Balance - (account.Balance % 100)) : 5000);
                        DateTime startdate = DateTime.Now.Date;
                        //Checks if there are any withdrawals earlier today. If true: compares maxvalue to max ammount per day
                        if ((dataContext.Transactions.Count(t => t.TransactionType == "Uttag" && t.TransactionTime > startdate && t.Account.Id == account.Id) != 0))
                        {
                            var withdraws = dataContext.Transactions.Where(t => t.TransactionType == "Uttag" && t.TransactionTime > startdate && t.Account.Id == account.Id).Sum(x => x.Amount);
                            maxvalue = ((10000 - withdraws < maxvalue ? (10000 - maxvalue) : maxvalue));
                        }
                        ViewBag.SliderMaxValue = maxvalue;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return RedirectToAction("Create", "Withdraw");
                    }

                }
            }
            //Where to add the slider????
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

                        //If the ammount is in hundreds
                        if (model.Amount % 100 == 0)
                        {
                            //If account balance is enough
                            if (account.Balance > model.Amount)
                            {
                                account.Balance -= model.Amount;
                                dataContext.SaveChanges();
                                trans.Commit();

                                dataContext.ClickLogs.Add(new ClickLog { Time = DateTime.Now, TurnOut = "Lyckades", Amount = model.Amount, EventType = "Uttag", UserName = User.Identity.Name });
                                dataContext.SaveChanges();
                                trans.Commit();
                            }
                            else
                            {
                                throw new Exception("Det saknas pengar på kontot");
                            }
                        }
                        else
                        {
                            throw new Exception("Observera att lägsta valör är 100-lappar");
                        }

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        dataContext.ClickLogs.Add(new ClickLog { Time = DateTime.Now, TurnOut = ex.Message, Amount = model.Amount, EventType = "Uttag", UserName = User.Identity.Name });
                        dataContext.SaveChanges();
                        ModelState.AddModelError("", ex);

                        return RedirectToAction("Create", "Withdraw");

                        //return View("error", ex);
                    }

                }
            }
            //Return to startpage and (TODO: automatically log out)
            return RedirectToAction("Index", "Home");
        }
    }
}
