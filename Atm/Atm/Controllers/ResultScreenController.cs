using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Controllers
{
    public class ResultScreenController : Controller
    {
        // GET: ResultScreen
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResultScreen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultScreen/Create
        public ActionResult Create(double amount, bool print, bool mail)
        {
            double fivehundreds = (amount - (amount % 500))/500;
            double hundreds = (amount - (fivehundreds * 500)) / 100;
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
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ResultScreen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResultScreen/Edit/5
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

        // GET: ResultScreen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResultScreen/Delete/5
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
