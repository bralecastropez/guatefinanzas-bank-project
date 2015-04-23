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
    public class CreditCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CardHelper CardHelp = new CardHelper();
        private EnumHelper<Enumeration.CreditCardType> Eh_CC = new EnumHelper<Enumeration.CreditCardType>();
        private EnumHelper<Enumeration.State> Eh_State = new EnumHelper<Enumeration.State>();

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
            ViewBag.Type = new SelectList(Eh_CC.GetEnumValues(), "Value", "Text");
            ViewBag.State = new SelectList(Eh_State.GetEnumValues(), "Value", "Text");

            return View();
        }

        // POST: /CreditCards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PersonID,Pin,Type,State,CreditLimit,Rate,ActivationDate")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                //creditcard.ID = CardHelp.GetNumberCreditCard(creditcard.Type.ToString());
                creditcard.ID = 1;
                db.CreditCards.Add(creditcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", creditcard.PersonID);
            ViewBag.Type = new SelectList(Eh_CC.GetEnumValues(), "Value", "Text", Eh_CC.GetIDByName(creditcard.Type.ToString()));
            ViewBag.State = new SelectList(Eh_State.GetEnumValues(), "Value", "Text", Eh_State.GetIDByName(creditcard.State.ToString()));

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
            ViewBag.Type = new SelectList(Eh_CC.GetEnumValues(), "Value", "Text", Eh_CC.GetIDByName(creditcard.Type.ToString()));
            ViewBag.State = new SelectList(Eh_State.GetEnumValues(), "Value", "Text", Eh_State.GetIDByName(creditcard.State.ToString()));

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
            ViewBag.Type = new SelectList(Eh_CC.GetEnumValues(), "Value", "Text", Eh_CC.GetIDByName(creditcard.Type.ToString()));
            ViewBag.State = new SelectList(Eh_State.GetEnumValues(), "Value", "Text", Eh_State.GetIDByName(creditcard.State.ToString()));

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
