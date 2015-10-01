using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Controllers
{
    public class ResultScreenController : Controller
    {
        // GET: ResultScreen/Create
        public ActionResult Create(int fivehundreds, int hundreds, bool print, bool mail)
        {
            ViewBag.Fivehundreds = fivehundreds;
            ViewBag.Hundreds = hundreds;
            ViewBag.Print = (print == true ? "Var god tag ditt kvitto." : "");
            ViewBag.mail = (mail == true ? "Ditt kvitto har mailats till dig." : "");
            return View();
        }

        // POST: ResultScreen/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {               
                return RedirectToAction("LogOff", "Account");
            }
            catch
            {
                return View();
            }
        }
    }
}
