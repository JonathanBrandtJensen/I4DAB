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
using Handin3._2;

namespace Handin3._2.Controllers
{
    public class EmailsController : ApiController
    {
        private KartotekContext db = new KartotekContext();

        // GET: api/Emails
        public IQueryable<EmailDTO> GetEmails()
        {
            List<Email> Etemp = db.Emails.ToList();
            var ADTOtemp = new List<EmailDTO>();
            foreach (var Email in Etemp)
            {

                var tempDTO = new EmailDTO()
                {
                    Emails = Email.Emails,
                    EmailType = Email.EmailType,
                    ContactId = Email.Contact_PersonId
                };
                ADTOtemp.Add(tempDTO);
            }

            return ADTOtemp.AsQueryable();
        }

        // GET: api/Emails/5
        [ResponseType(typeof(EmailDTO))]
        public IHttpActionResult GetEmail(string id)
        {
            Email Email = db.Emails.Find(id);
            if (Email == null)
            {
                return NotFound();
            }
            var tempDTO = new EmailDTO()
            {
                 Emails = Email.Emails,
                 EmailType = Email.EmailType,
                 ContactId = Email.Contact_PersonId
            };
            return Ok(tempDTO);
        }

        // PUT: api/Emails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmail(string id, Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.Emails)
            {
                return BadRequest();
            }

            db.Entry(email).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Emails
        [ResponseType(typeof(EmailDTO))]
        public IHttpActionResult PostEmail(Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emails.Add(email);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmailExists(email.Emails))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = email.Emails }, email);
        }

        // DELETE: api/Emails/5
        [ResponseType(typeof(Email))]
        public IHttpActionResult DeleteEmail(string id)
        {
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return NotFound();
            }

            db.Emails.Remove(email);
            db.SaveChanges();

            return Ok(email);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailExists(string id)
        {
            return db.Emails.Count(e => e.Emails == id) > 0;
        }
    }
}