using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.Repositories;

namespace HandIn3._3.Controllers
{
    public class ContactController : ApiController
    {
        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return WebApiApplication.ContactRepo.GetAllContacts();
        }

        // GET: api/Contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
