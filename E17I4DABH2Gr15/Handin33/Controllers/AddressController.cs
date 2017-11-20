using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandIn2._2.Collections.AddressCollection;

namespace Handin33.Controllers
{
    public class AddressController : ApiController
    {
        // GET: api/Address
        public IEnumerable<Address> Get()
        {
            return WebApiApplication.AddressRepo.GetAllAddresses();
        }

        // GET: api/Address/5
        public Address Get(string id)
        {
            var address = WebApiApplication.AddressRepo.Get(id);
            address.Contacts = WebApiApplication.ContactRepo.GetContactsByAddressId(id);
            return address;
        }

        // POST: api/Address
        public void Post(Address address)
        {
            WebApiApplication.AddressRepo.Create(address);
        }

        // PUT: api/Address/5
        public void Put(Address address)
        {
            WebApiApplication.AddressRepo.Update(address);
        }

        // DELETE: api/Address/5
        public void Delete(string id)
        {
            var contactList = WebApiApplication.ContactRepo.GetContactsByAddressId(id);
            foreach (var contact in contactList)
            {
                contact.AddressIds.Remove(Guid.Parse(id));
                WebApiApplication.ContactRepo.Update(contact);
            }
            WebApiApplication.AddressRepo.Delete(Guid.Parse(id));
        }
    }
}
