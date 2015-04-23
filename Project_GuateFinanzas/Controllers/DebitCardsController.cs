using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Project_GuateFinanzas.Models;
using Project_GuateFinanzas.Helpers;

namespace Project_GuateFinanzas.Controllers
{
    public class DebitCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private EnumHelper<Enumeration.State> Eh_Stat = new EnumHelper<Enumeration.State>();
        private CardHelper Ch_DC = new CardHelper();
             
        // GET: /DebitCards/
        public ActionResult Index()
        {
            var debitcards = db.DebitCards.Include(d => d.BankAccount);
            return View(debitcards.ToList());
        }

        // GET: /DebitCards/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitCard debitcard = db.DebitCards.Find(id);
            if (debitcard == null)
            {
                return HttpNotFound();
            }
            return View(debitcard);
        }

        // GET: /DebitCards/Create
        public ActionResult Create()
        {
            ViewBag.BankAccountID = new SelectList(db.BankAccounts, "ID", "Name");
            ViewBag.State = new SelectList(Eh_Stat.GetEnumValues(), "Value", "Text");

            return View();
        }

        // POST: /DebitCards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BankAccountID,Pin,State,ActivationDate")] DebitCard debitcard)
        {
            if (ModelState.IsValid)
            {
                debitcard.ID = Ch_DC.GetNumberForDebitCard();
                db.DebitCards.Add(debitcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankAccountID = new SelectList(db.BankAccounts, "ID", "Name", debitcard.BankAccountID);
            ViewBag.State = new SelectList(Eh_Stat.GetEnumValues(), "Value", "Text");

            return View(debitcard);
        }

        // GET: /DebitCards/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitCard debitcard = db.DebitCards.Find(id);
            if (debitcard == null)
            {
                return HttpNotFound();
            }

            ViewBag.BankAccountID = new SelectList(db.BankAccounts, "ID", "Name", debitcard.BankAccountID);
            ViewBag.State = new SelectList(Eh_Stat.GetEnumValues(), "Value", "Text", Eh_Stat.GetIDByName(debitcard.State.ToString()));

            return View(debitcard);
        }

        // POST: /DebitCards/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,BankAccountID,Pin,State,ActivationDate")] DebitCard debitcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debitcard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankAccountID = new SelectList(db.BankAccounts, "ID", "Name", debitcard.BankAccountID);
            ViewBag.State = new SelectList(Eh_Stat.GetEnumValues(), "Value", "Text", Eh_Stat.GetIDByName(debitcard.State.ToString()));

            return View(debitcard);
        }

        // GET: /DebitCards/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitCard debitcard = db.DebitCards.Find(id);
            if (debitcard == null)
            {
                return HttpNotFound();
            }
            return View(debitcard);
        }

        // POST: /DebitCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DebitCard debitcard = db.DebitCards.Find(id);
            db.DebitCards.Remove(debitcard);
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
