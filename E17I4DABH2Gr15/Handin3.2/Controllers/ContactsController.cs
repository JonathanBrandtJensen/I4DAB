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
    public class ContactsController : ApiController
    {
        private KartotekContext db = new KartotekContext();

        // GET: api/Contacts
        public IQueryable<ContactDTO> GetContacts()
        {
            List<Contact> Ctemp = db.Contacts.ToList();
            var CDTOtemp = new List<ContactDTO>();
            foreach (var Contact in Ctemp)
            {

                var tempDTO = new ContactDTO()
                {
                    Contacts = Contact.Contacts,
                    FirstName = Contact.FirstName,
                    MiddleName = Contact.MiddleName,
                    LastName = Contact.LastName,
                    PersonType = Contact.PersonType,
                    EmailIds = new List<string>(),
                    TelephoneIds = new List<string>(),
                    AddressIds = new List<int>(),
                };
                foreach (var Address in Contact.Addresses)
                {
                    tempDTO.AddressIds.Add(Address.Addresses);
                }
                foreach (var Email in Contact.Emails)
                {
                    tempDTO.EmailIds.Add(Email.Emails);
                }
                foreach (var Telephone in Contact.Telephones)
                {
                    tempDTO.TelephoneIds.Add(Telephone.TelephoneNr);
                }
                CDTOtemp.Add(tempDTO);
            }

            return CDTOtemp.AsQueryable();
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(ContactDTO))]
        public IHttpActionResult GetContact(int id)
        {
            Contact Contact = db.Contacts.Find(id);
            if (Contact == null)
            {
                return NotFound();
            }
            var tempDTO = new ContactDTO()
            {
                Contacts = Contact.Contacts,
                FirstName = Contact.FirstName,
                MiddleName = Contact.MiddleName,
                LastName = Contact.LastName,
                PersonType = Contact.PersonType,
                EmailIds = new List<string>(),
                TelephoneIds = new List<string>(),
                AddressIds = new List<int>(),
            };
            foreach (var Address in Contact.Addresses)
            {
                tempDTO.AddressIds.Add(Address.Addresses);
            }
            foreach (var Email in Contact.Emails)
            {
                tempDTO.EmailIds.Add(Email.Emails);
            }
            foreach (var Telephone in Contact.Telephones)
            {
                tempDTO.TelephoneIds.Add(Telephone.TelephoneNr);
            }
            return Ok(tempDTO);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Contacts)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            Contact Contact = db.Contacts.Find(contact.Contacts);
            if (Contact == null)
            {
                return NotFound();
            }
            var tempDTO = new ContactDTO()
            {
                Contacts = Contact.Contacts,
                FirstName = Contact.FirstName,
                MiddleName = Contact.MiddleName,
                LastName = Contact.LastName,
                PersonType = Contact.PersonType,
                EmailIds = new List<string>(),
                TelephoneIds = new List<string>(),
                AddressIds = new List<int>(),
            };
            foreach (var Address in Contact.Addresses)
            {
                tempDTO.AddressIds.Add(Address.Addresses);
            }
            foreach (var Email in Contact.Emails)
            {
                tempDTO.EmailIds.Add(Email.Emails);
            }
            foreach (var Telephone in Contact.Telephones)
            {
                tempDTO.TelephoneIds.Add(Telephone.TelephoneNr);
            }
            return CreatedAtRoute("DefaultApi", new { id = contact.Contacts }, tempDTO);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            var tmpContact = db.Contacts.Find(id);
            if (tmpContact == null)
            {
                return NotFound();
            }
            db.Telephones.RemoveRange(tmpContact.Telephones);
            db.Addresses.RemoveRange(tmpContact.Addresses);
            db.Emails.RemoveRange(tmpContact.Emails);
            db.Contacts.Remove(tmpContact);
            db.SaveChanges();

            return Ok(tmpContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Contacts == id) > 0;
        }
    }
}