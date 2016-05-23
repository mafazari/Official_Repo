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
    public class PasAPIController : ApiController
    {
        private BankContext db = new BankContext();

        // GET: api/PasAPI
        public IQueryable<Pas> GetPas()
        {
            return db.Pas;
        }

        // GET: api/PasAPI/5
        [ResponseType(typeof(Pas))]
        public IHttpActionResult GetPas(string id)
        {
            Pas pas = db.Pas.Find(id);
            if (pas == null)
            {
                return NotFound();
            }

            return Ok(pas);
        }

        // PUT: api/PasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPas(string id, Pas pas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pas.PasID)
            {
                return BadRequest();
            }

            db.Entry(pas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasExists(id))
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

        // POST: api/PasAPI
        [ResponseType(typeof(Pas))]
        public IHttpActionResult PostPas(Pas pas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pas.Add(pas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PasExists(pas.PasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pas.PasID }, pas);
        }

        // DELETE: api/PasAPI/5
        [ResponseType(typeof(Pas))]
        public IHttpActionResult DeletePas(string id)
        {
            Pas pas = db.Pas.Find(id);
            if (pas == null)
            {
                return NotFound();
            }

            db.Pas.Remove(pas);
            db.SaveChanges();

            return Ok(pas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasExists(string id)
        {
            return db.Pas.Count(e => e.PasID == id) > 0;
        }
    }
}