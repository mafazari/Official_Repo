using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class KlantsAPIController : ApiController
    {
        private BankContext db = new BankContext();

        // GET: api/KlantsAPI
        public IQueryable<Klant> GetKlants()
        {
            return db.Klants;
        }

        // GET: api/KlantsAPI/5
        [ResponseType(typeof(Klant))]
        public IHttpActionResult GetKlant(int id)
        {
            Klant klant = db.Klants.Find(id);
            if (klant == null)
            {
                return NotFound();
            }

            return Ok(klant);
        }

        // PUT: api/KlantsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlant(int id, Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klant.KlantID)
            {
                return BadRequest();
            }

            db.Entry(klant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KlantsAPI
        [ResponseType(typeof(Klant))]
        public IHttpActionResult PostKlant(Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klants.Add(klant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klant.KlantID }, klant);
        }

        // DELETE: api/KlantsAPI/5
        [ResponseType(typeof(Klant))]
        public IHttpActionResult DeleteKlant(int id)
        {
            Klant klant = db.Klants.Find(id);
            if (klant == null)
            {
                return NotFound();
            }

            db.Klants.Remove(klant);
            db.SaveChanges();

            return Ok(klant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlantExists(int id)
        {
            return db.Klants.Count(e => e.KlantID == id) > 0;
        }
    }
}