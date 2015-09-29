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
        public ActionResult Index()
        {
            using (ApplicationDbContext dataContext = new ApplicationDbContext())
            {
                using (var trans = dataContext.Database.BeginTransaction())
                {

                    Receipt receipt = dataContext.Receipts.Where(r => r.Active).First();
                    if (receipt.Length < 0.3)
                    {
                        ViewBag.ReceiptError = "Kvitto kan inte lämnas";
                    }


                    int hundredBils = dataContext.Money.Count(p => p.Denominator == 100);
                    int fiveHundredBills = dataContext.Money.Count(p => p.Denominator == 500);

                    if (hundredBils < 1 && fiveHundredBills < 1)
                    {
                        ViewBag.OutOfBillsError = "Slut på sedlar";
                    }
                    else if (hundredBils < 1)
                    {
                        ViewBag.OutOfHundredBillsError = "Endast möjligt att ta ut 500-sedlar";
                    }


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