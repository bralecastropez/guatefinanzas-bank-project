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
    public class BankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private EnumHelper<Enumeration.AccountType> EhActTyp = new EnumHelper<Enumeration.AccountType>();
        private EnumHelper<Enumeration.State> EhSt = new EnumHelper<Enumeration.State>();
        private BankAcHelper BacHelper = new BankAcHelper();

        // GET: /BankAccounts/
        public ActionResult Index()
        {
            var bankaccounts = db.BankAccounts.Include(b => b.Person);
            return View(bankaccounts.ToList());
        }

        // GET: /BankAccounts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        // GET: /BankAccounts/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name");
            ViewBag.Type = new SelectList(EhActTyp.GetEnumValues(), "Value", "Text");
            ViewBag.State = new SelectList(EhSt.GetEnumValues(), "Value", "Text");
            return View();
        }

        // POST: /BankAccounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PersonID,Name,Balance,Type,State,LRN1st,LRNP1st,LRN2nd,LRNP2nd")] BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                if (bankaccount.Type == Enumeration.AccountType.Monetary)
                {
                    bankaccount.ID = BacHelper.GetIDMonetaryAccount();
                }
                else 
                {
                    bankaccount.ID = BacHelper.GetIDSavingAccount();
                }
                db.BankAccounts.Add(bankaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", bankaccount.PersonID);
            ViewBag.Type = new SelectList(EhActTyp.GetEnumValues(), "Value", "Text", EhActTyp.GetIDByName(bankaccount.Type.ToString()));
            ViewBag.State = new SelectList(EhSt.GetEnumValues(), "Value", "Text", EhSt.GetIDByName(bankaccount.State.ToString()));
            return View(bankaccount);
        }

        // GET: /BankAccounts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", bankaccount.PersonID);
            ViewBag.Type = new SelectList(EhActTyp.GetEnumValues(), "Value", "Text", EhActTyp.GetIDByName(bankaccount.Type.ToString()));
            ViewBag.State = new SelectList(EhSt.GetEnumValues(), "Value", "Text", EhSt.GetIDByName(bankaccount.State.ToString()));

            return View(bankaccount);
        }

        // POST: /BankAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PersonID,Name,Balance,Type,State,LRN1st,LRNP1st,LRN2nd,LRNP2nd")] BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", bankaccount.PersonID);
            ViewBag.Type = new SelectList(EhActTyp.GetEnumValues(), "Value", "Text", EhActTyp.GetIDByName(bankaccount.Type.ToString()));
            ViewBag.State = new SelectList(EhSt.GetEnumValues(), "Value", "Text", EhSt.GetIDByName(bankaccount.State.ToString()));

            return View(bankaccount);
        }

        // GET: /BankAccounts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        // POST: /BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankaccount);
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
