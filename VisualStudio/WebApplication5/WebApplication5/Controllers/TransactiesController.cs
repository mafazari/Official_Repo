﻿using System;
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
    public class TransactiesController : Controller
    {
        private BankContext db = new BankContext();

        // GET: Transacties
        public ActionResult Index()
        {
            return View(db.Transacties.ToList());
        }

        // GET: Transacties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactie transactie = db.Transacties.Find(id);
            if (transactie == null)
            {
                return HttpNotFound();
            }
            return View(transactie);
        }

        // GET: Transacties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactieID,RekeningID,Bedrag,PasID")] Transactie transactie)
        {
            if (ModelState.IsValid)
            {
                db.Transacties.Add(transactie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactie);
        }

        // GET: Transacties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactie transactie = db.Transacties.Find(id);
            if (transactie == null)
            {
                return HttpNotFound();
            }
            return View(transactie);
        }

        // POST: Transacties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactieID,RekeningID,Bedrag,PasID")] Transactie transactie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactie);
        }

        // GET: Transacties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactie transactie = db.Transacties.Find(id);
            if (transactie == null)
            {
                return HttpNotFound();
            }
            return View(transactie);
        }

        // POST: Transacties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transactie transactie = db.Transacties.Find(id);
            db.Transacties.Remove(transactie);
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
