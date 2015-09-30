using Atm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Controllers
{
    public class HomeController : Controller
    {
        public static bool AtmOutOfOrder = false;


        public ActionResult Index()
        {

            if (AtmOutOfOrder)
            {
                return View("OutOfOrder");
            }

            using (ApplicationDbContext dataContext = new ApplicationDbContext())
            {
                using (var trans = dataContext.Database.BeginTransaction())
                {

                    List<string> errorMessages = new List<string>();

                    Receipt receipt = dataContext.Receipts.First(r => r.Active);
                    if (receipt.Length < 0.3)
                    {
                        errorMessages.Add("Kvitto kan inte lämnas");
                    }


                    int hundredBills = dataContext.Money.Count(p => p.Denominator == 100);
                    int fiveHundredBills = dataContext.Money.Count(p => p.Denominator == 500);

                    if (hundredBills < 1 && fiveHundredBills < 1)
                    {
                        return View("OutOfOrder");
                    }
                    else
                    {
                        if (hundredBills < 1)
                        {
                            errorMessages.Add("Endast möjligt att ta ut 500-sedlar");
                        }
                        if (fiveHundredBills < 1)
                        {
                            errorMessages.Add("Endast möjligt att ta ut 100-sedlar");
                        }
                    }
                    ViewBag.ErrorMessages = errorMessages;


                    return View();
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}