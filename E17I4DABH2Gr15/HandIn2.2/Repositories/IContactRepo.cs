using System.Collections.Generic;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;

namespace HandIn2._2.Repositories
{
    public interface IContactRepo : IGenericRepo<Contact>
    {
        List<Contact> GetAllContacts();
        List<Contact> GetContactsByAddressId(string addressId);
    }
}