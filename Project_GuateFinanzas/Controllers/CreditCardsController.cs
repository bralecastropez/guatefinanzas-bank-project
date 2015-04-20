using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_GuateFinanzas.Models;

namespace Project_GuateFinanzas.Controllers
{
    public class CreditCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /CreditCards/
        public ActionResult Index()
        {
            var creditcards = db.CreditCards.Include(c => c.Person);
            return View(creditcards.ToList());
        }

        // GET: /CreditCards/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        // GET: /CreditCards/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name");
            return View();
        }

        // POST: /CreditCards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PersonID,Pin,Type,State,CreditLimit,Rate,ActivationDate")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                db.CreditCards.Add(creditcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", creditcard.PersonID);
            return View(creditcard);
        }

        // GET: /CreditCards/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", creditcard.PersonID);
            return View(creditcard);
        }

        // POST: /CreditCards/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PersonID,Pin,Type,State,CreditLimit,Rate,ActivationDate")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditcard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", creditcard.PersonID);
            return View(creditcard);
        }

        // GET: /CreditCards/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        // POST: /CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CreditCard creditcard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditcard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
