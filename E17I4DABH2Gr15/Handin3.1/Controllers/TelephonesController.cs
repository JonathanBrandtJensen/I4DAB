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
using Handin3._1;

namespace Handin3._1.Controllers
{
    public class TelephonesController : ApiController
    {
        private PersonkartotekContext db = new PersonkartotekContext();

        // GET: api/Telephones
        public IQueryable<Telephone> GetTelephones()
        {
            return db.Telephones;
        }

        // GET: api/Telephones/5
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult GetTelephone(string id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            return Ok(telephone);
        }

        // PUT: api/Telephones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelephone(string id, Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telephone.TelephoneNr)
            {
                return BadRequest();
            }

            db.Entry(telephone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneExists(id))
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

        // POST: api/Telephones
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult PostTelephone(Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telephones.Add(telephone);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TelephoneExists(telephone.TelephoneNr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = telephone.TelephoneNr }, telephone);
        }

        // DELETE: api/Telephones/5
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult DeleteTelephone(string id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            db.Telephones.Remove(telephone);
            db.SaveChanges();

            return Ok(telephone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelephoneExists(string id)
        {
            return db.Telephones.Count(e => e.TelephoneNr == id) > 0;
        }
    }
}