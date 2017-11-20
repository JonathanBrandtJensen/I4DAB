using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using Microsoft.Ajax.Utilities;

namespace Handin33.Controllers
{
    public class ContactController : ApiController
    {
        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return WebApiApplication.ContactRepo.GetAllContacts();
        }

        // GET: api/Contact/5
        public Contact Get(string id)
        {
            var contact = WebApiApplication.ContactRepo.Get(id);
            contact.Addresses = WebApiApplication.AddressRepo.GetAddressListByContact(contact);
            return contact;
        }

        // POST: api/Contact
        public string Post(Contact contact)
        {
            var tempAddressList = contact.Addresses;
            contact.Addresses = null;
            contact.Id = Guid.NewGuid();
            foreach (Address address in tempAddressList)
            {
                /*var checkExistingAddress = WebApiApplication.AddressRepo.GetAllAddresses().Where(f => f.AddressType == address.AddressType &&
                    f.HousNr == address.HousNr &&
                    f.Streetname == address.Streetname &&
                    f.PostCode == address.PostCode);*/
                var checkAddress = WebApiApplication.AddressRepo.CheckExisting(address);
                if (checkAddress != null)
                {
                    checkAddress.ContactIds.Add(contact.Id);
                    WebApiApplication.AddressRepo.Update(checkAddress);
                    contact.AddressIds.Add(checkAddress.Id);
                }
                else
                {
                    address.Id = Guid.NewGuid();
                    address.ContactIds.Add(contact.Id);
                    var returnAddressCheck = WebApiApplication.AddressRepo.Create(address);
                    if (!returnAddressCheck.IsNullOrWhiteSpace())
                    {
                        contact.AddressIds.Add(Guid.Parse(returnAddressCheck));
                    }
                }
            }
            var returnContactCheck = WebApiApplication.ContactRepo.Create(contact);
            if (!returnContactCheck.IsNullOrWhiteSpace())
            {
                return returnContactCheck;
            }
            return null;
        }

        // PUT: api/Contact/5
        public void Put(Contact contact)
        {
            if (contact.Addresses != null)
            {
                foreach (var address in contact.Addresses)
                {
                    var readResponse = WebApiApplication.AddressRepo.Get(address.Id.ToString());
                    if (readResponse == null)
                    {
                        address.Id = Guid.NewGuid();
                        address.ContactIds.Add(contact.Id);
                        var createResponse = WebApiApplication.AddressRepo.Create(address);
                        contact.AddressIds.Add(Guid.Parse(createResponse));
                    }
                    else
                    {
                        WebApiApplication.AddressRepo.Update(address);
                    }
                }
            }
            contact.Addresses = null;
            WebApiApplication.ContactRepo.Update(contact);
        }

        // DELETE: api/Contact/5
        public void Delete(Guid id)
        {
            var contactToDelete = WebApiApplication.ContactRepo.Get(id.ToString());
            var addressList = WebApiApplication.AddressRepo.GetAddressListByContact(contactToDelete);
            foreach (Address address in addressList)
            {
                address.ContactIds.Remove(id);
                if (address.ContactIds.Count == 0)
                {
                    WebApiApplication.AddressRepo.Delete(address.Id);
                }
                else
                {
                    WebApiApplication.AddressRepo.Update(address);
                }
            }
            WebApiApplication.ContactRepo.Delete(id);
        }
    }
}
