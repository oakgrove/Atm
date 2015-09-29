using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Controllers
{
    public class WithdrawController : Controller
    {
        // GET: Withdraw
        public ActionResult Index()
        {
            return View();
        }

        // GET: Withdraw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Withdraw/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
