using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Controllers
{
    public class BankAccountViewController : Controller
    {
        // GET: BankAccountView
        public ActionResult Index()
        {
            return View();
        }

        // GET: BankAccountView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankAccountView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccountView/Create
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

        // GET: BankAccountView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankAccountView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccountView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankAccountView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
