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
    [Authorize(Roles = "Admin")]
    public class BankAccountMovementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BankAccMovementHelper BaMHelp = new BankAccMovementHelper();

        // GET: /BankAccountMovements/
        public ActionResult Index()
        {
            return View(db.AccountMovements.ToList());
        }

        // GET: /BankAccountMovements/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountMovement accountmovement = db.AccountMovements.Find(id);
            if (accountmovement == null)
            {
                return HttpNotFound();
            }
            return View(accountmovement);
        }

        // GET: /BankAccountMovements/Create
        public ActionResult Create(string MoveType)
        {
            ViewBag.AccountID = new SelectList(db.BankAccounts, "ID", "Name");
            ViewBag.MoveType = MoveType;
            if (MoveType == "DebitCardWithdrawal")
                ViewBag.DebitCards = new SelectList(db.DebitCards, "ID", "ID");

            return View();
        }

        // POST: /BankAccountMovements/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovementDate,Balance,Amount,AccountID,TargetAccountID,CheckNumber,DebitCardNum,Location")] AccountMovement accountmovement, string type)
        {
            if (type == "Deposit")
            {
                accountmovement.MovementType = Enumeration.TypeAccountActivity.Deposit;
            }
            if(type == "Withdraw")
            {
                accountmovement.MovementType = Enumeration.TypeAccountActivity.Withdraw;
            }
            if(type == "DebitCardWithdrawal")
            {
                accountmovement.MovementType = Enumeration.TypeAccountActivity.DebitCardWithdrawal;
            }
            if(type == "Transfer")
            {
                accountmovement.MovementType = Enumeration.TypeAccountActivity.Transfer;
                type = "Trasfer";
            }
            if (ModelState.IsValid)
            {

                var bankAccount = db.BankAccounts.SingleOrDefault(ba => ba.ID == accountmovement.AccountID);
                accountmovement.ActivityState = Enumeration.ActivityStatus.Failed;

                if (accountmovement.MovementType == Enumeration.TypeAccountActivity.DebitCardWithdrawal || accountmovement.MovementType == Enumeration.TypeAccountActivity.Withdraw || accountmovement.MovementType == Enumeration.TypeAccountActivity.Transfer)
                {
                    if (bankAccount.Balance >= accountmovement.Amount)
                    {
                        if (type == "Transfer")
                        {
                            var TargetAccount = db.BankAccounts.SingleOrDefault(ta => ta.ID == accountmovement.TargetAccountID);
                            TargetAccount.Balance += accountmovement.Amount;
                        }
                        bankAccount.Balance -= accountmovement.Amount;
                        accountmovement.ActivityState = Enumeration.ActivityStatus.Successful;
                    }
                }
                else 
                {
                    bankAccount.Balance += accountmovement.Amount;
                    accountmovement.ActivityState = Enumeration.ActivityStatus.Successful;
                }

                db.AccountMovements.Add(accountmovement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.BankAccounts, "ID", "Name", accountmovement.AccountID);

            if (type == "DebitCardWithdrawal")
                ViewBag.DebitCards = new SelectList(db.DebitCards, "ID", "ID", accountmovement.TargetAccountID);

            return View(accountmovement);
        }

        // GET: /BankAccountMovements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountMovement accountmovement = db.AccountMovements.Find(id);
            if (accountmovement == null)
            {
                return HttpNotFound();
            }
            return View(accountmovement);
        }

        // POST: /BankAccountMovements/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,MovementDate,Balance,Amount,AccountID,MovementType,ActivityState,TargetAccountID,CheckNumber,DebitCardNum,Location")] AccountMovement accountmovement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountmovement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountmovement);
        }

        // GET: /BankAccountMovements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountMovement accountmovement = db.AccountMovements.Find(id);
            if (accountmovement == null)
            {
                return HttpNotFound();
            }
            return View(accountmovement);
        }

        // POST: /BankAccountMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountMovement accountmovement = db.AccountMovements.Find(id);
            db.AccountMovements.Remove(accountmovement);
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
