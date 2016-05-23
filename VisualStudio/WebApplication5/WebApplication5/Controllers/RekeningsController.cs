using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class RekeningsController : Controller
    {
        private BankContext db = new BankContext();

        // GET: Rekenings
        public ActionResult Index()
        {
            return View(db.Rekenings.ToList());
        }

        // GET: Rekenings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekening rekening = db.Rekenings.Find(id);
            if (rekening == null)
            {
                return HttpNotFound();
            }
            return View(rekening);
        }

        // GET: Rekenings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rekenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RekeningNr,Balans,RekeningType,KlantNr,Hash")] Rekening rekening)
        {
            if (ModelState.IsValid)
            {
                db.Rekenings.Add(rekening);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rekening);
        }

        // GET: Rekenings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekening rekening = db.Rekenings.Find(id);
            if (rekening == null)
            {
                return HttpNotFound();
            }
            return View(rekening);
        }

        // POST: Rekenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RekeningNr,Balans,RekeningType,KlantNr,Hash")] Rekening rekening)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rekening).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rekening);
        }

        // GET: Rekenings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekening rekening = db.Rekenings.Find(id);
            if (rekening == null)
            {
                return HttpNotFound();
            }
            return View(rekening);
        }

        // POST: Rekenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rekening rekening = db.Rekenings.Find(id);
            db.Rekenings.Remove(rekening);
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
