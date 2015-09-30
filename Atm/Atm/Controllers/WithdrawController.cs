using Atm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Atm.DAL;

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
        public ActionResult Create(string errormsg)
        {
            using (ApplicationDbContext dataContext = new ApplicationDbContext())
            {
                using (var trans = dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        BankAccount account = dataContext.Accounts.First(a => a.WithdrawAccount == true && a.User.UserName == User.Identity.Name);
                        double maxvalue = (account.Balance < 5000 ? (account.Balance - (account.Balance % 100)) : 5000);
                        DateTime startdate = DateTime.Now.Date;
                        //Checks if there are any withdrawals earlier today. If true: compares maxvalue to max ammount per day
                        if ((dataContext.Transactions.Count(t => t.TransactionType == "Uttag" && t.TransactionTime > startdate && t.Account.Id == account.Id) != 0))
                        {
                            var withdraws = dataContext.Transactions.Where(t => t.TransactionType == "Uttag" && t.TransactionTime > startdate && t.Account.Id == account.Id).Sum(x => x.Amount);
                            maxvalue = ((10000 - withdraws < maxvalue ? (10000 - withdraws) : maxvalue));
                        }
                        ViewBag.SliderMaxValue = maxvalue;

                        int hundredBills = dataContext.Money.Where(p => p.Denominator == 100).Sum(x => x.RemainingPieces);
                        ViewBag.Step = (hundredBills==0) ? 500 : 100;

                        bool receiptLeft = true;
                        Receipt receipt = dataContext.Receipts.First(r => r.Active);
                        if (receipt.Length < 0.3)
                            receiptLeft = false;
                        ViewBag.receiptLeft = receiptLeft;

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return RedirectToAction("Create", "Withdraw");
                    }
                }
            }
            ViewBag.ErrMsg = errormsg;
            return View();
        }

        // POST: Withdraw/Create
        [HttpPost]
        public ActionResult Create(WithdrawViewModel model, string details, string ok)
        {
            if (string.IsNullOrWhiteSpace(details))
            {
                using (ApplicationDbContext dataContext = new ApplicationDbContext())
                {
                    using (var trans = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            BankAccount account = dataContext.Accounts.First(a => a.WithdrawAccount == true && a.User.UserName == User.Identity.Name);

                            //If the ammount is in hundreds
                            if (model.Amount % 100 == 0)
                            {
                                //If account balance is enough
                                if (account.Balance > model.Amount)
                                {
                                    account.Balance -= model.Amount;
                                    dataContext.Transactions.Add(new Transaction { TransactionTime = DateTime.Now, Account = account, Balance = account.Balance, Amount = model.Amount, TransactionType = "Uttag" });
                                    dataContext.SaveChanges();
                                    trans.Commit();

                                    using (ApplicationDbContext dContext = new ApplicationDbContext())
                                    {
                                        dataContext.ClickLogs.Add(new ClickLog { Time = DateTime.Now, TurnOut = "Lyckades", Amount = model.Amount, EventType = "Uttag", UserName = User.Identity.Name });
                                        dataContext.SaveChanges();
                                    }

                                }
                                else
                                {
                                    throw new Exception("Det saknas pengar på kontot");
                                }
                            }
                            else
                            {
                                throw new Exception("Observera att du endast kan ta ut pengar i hundratal");
                            }

                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            string msg = (ex.Message == "Det saknas pengar på kontot" ? "Användaren försökte ta ut mer pengar än vad som fanns på kontot" : $"Användaren försökte ta ut {model.Amount} kr");
                            dataContext.ClickLogs.Add(new ClickLog { Time = DateTime.Now, TurnOut = msg, Amount = model.Amount, EventType = "Uttag", UserName = User.Identity.Name });
                            dataContext.SaveChanges();
                            ModelState.AddModelError("", ex);
                            return RedirectToAction("Create", "Withdraw", new { errormsg = ex.Message });
                        }
                    }
                }
                //Return to startpage and (TODO: automatically log out)
                return RedirectToAction("Create", "ResultScreen", new { amount = model.Amount, print = model.PrintReceipt, mail = model.EmailReceipt });
            }
            else
            {
                return RedirectToAction("Index", "BankAccount");
            }
        }
    }
}
