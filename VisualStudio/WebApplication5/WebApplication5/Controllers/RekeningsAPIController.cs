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
    public class RekeningsAPIController : ApiController
    {
        private BankContext db = new BankContext();

        // GET: api/RekeningsAPI
        public IQueryable<Rekening> GetRekenings()
        {
            return db.Rekenings;
        }

        // GET: api/RekeningsAPI/5
        [ResponseType(typeof(Rekening))]
        public IHttpActionResult GetRekening(int id)
        {
            Rekening rekening = db.Rekenings.Find(id);
            if (rekening == null)
            {
                return NotFound();
            }

            return Ok(rekening);
        }

        // PUT: api/RekeningsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRekening(int id, Rekening rekening)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rekening.RekeningNr)
            {
                return BadRequest();
            }

            db.Entry(rekening).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RekeningExists(id))
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

        // POST: api/RekeningsAPI
        [ResponseType(typeof(Rekening))]
        public IHttpActionResult PostRekening(Rekening rekening)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rekenings.Add(rekening);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rekening.RekeningNr }, rekening);
        }

        // DELETE: api/RekeningsAPI/5
        [ResponseType(typeof(Rekening))]
        public IHttpActionResult DeleteRekening(int id)
        {
            Rekening rekening = db.Rekenings.Find(id);
            if (rekening == null)
            {
                return NotFound();
            }

            db.Rekenings.Remove(rekening);
            db.SaveChanges();

            return Ok(rekening);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RekeningExists(int id)
        {
            return db.Rekenings.Count(e => e.RekeningNr == id) > 0;
        }
    }
}