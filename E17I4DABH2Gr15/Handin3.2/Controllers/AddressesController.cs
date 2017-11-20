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
    public class AddressesController : ApiController
    {
        private KartotekContext db = new KartotekContext();

        // GET: api/Addresses
        public IQueryable<AddressDTO> GetAddresses()
        {
            List<Address> Atemp = db.Addresses.ToList();
            var ADTOtemp = new List<AddressDTO>();
            foreach (var Address in Atemp)
            {

                var tempDTO = new AddressDTO()
                {
                    Addresses = Address.Addresses,
                    AddressType = Address.AddressType,
                    Streetname = Address.Streetname,
                    HousNr = Address.HousNr,
                    PostCodes = Address.PostCode_PostCodeId,
                    ContactIds = new List<int>()
                };
                foreach(var Contact in Address.Contacts)
                {
                    tempDTO.ContactIds.Add(Contact.Contacts);
                }
            ADTOtemp.Add(tempDTO);
            }
            
            return ADTOtemp.AsQueryable();
        }
        // GET: api/Addresses/5
        [ResponseType(typeof(AddressDTO))]
        public IHttpActionResult GetAddress(int id)
        {
            Address Address = db.Addresses.Find(id);
            if (Address == null)
            {
                return NotFound();
            }
            var tempDTO = new AddressDTO()
            {
                Addresses = Address.Addresses,
                AddressType = Address.AddressType,
                Streetname = Address.Streetname,
                HousNr = Address.HousNr,
                PostCodes = Address.PostCode_PostCodeId,
                ContactIds = new List<int>()
            };
            foreach (var Contact in Address.Contacts)
            {
                tempDTO.ContactIds.Add(Contact.Contacts);
            }
            return Ok(tempDTO);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.Addresses)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = address.Addresses }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.Addresses == id) > 0;
        }
    }
}