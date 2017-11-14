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
    public class PostCodesController : ApiController
    {
        private PersonkartotekContext db = new PersonkartotekContext();

        // GET: api/PostCodes
        public IQueryable<PostCode> GetPostCodes()
        {
            return db.PostCodes;
        }

        // GET: api/PostCodes/5
        [ResponseType(typeof(PostCode))]
        public IHttpActionResult GetPostCode(string id)
        {
            PostCode postCode = db.PostCodes.Find(id);
            if (postCode == null)
            {
                return NotFound();
            }

            return Ok(postCode);
        }

        // PUT: api/PostCodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostCode(string id, PostCode postCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postCode.PostCodes)
            {
                return BadRequest();
            }

            db.Entry(postCode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCodeExists(id))
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

        // POST: api/PostCodes
        [ResponseType(typeof(PostCode))]
        public IHttpActionResult PostPostCode(PostCode postCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostCodes.Add(postCode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PostCodeExists(postCode.PostCodes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = postCode.PostCodes }, postCode);
        }

        // DELETE: api/PostCodes/5
        [ResponseType(typeof(PostCode))]
        public IHttpActionResult DeletePostCode(string id)
        {
            PostCode postCode = db.PostCodes.Find(id);
            if (postCode == null)
            {
                return NotFound();
            }

            db.PostCodes.Remove(postCode);
            db.SaveChanges();

            return Ok(postCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostCodeExists(string id)
        {
            return db.PostCodes.Count(e => e.PostCodes == id) > 0;
        }
    }
}