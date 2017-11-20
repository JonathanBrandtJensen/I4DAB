using System.Collections.Generic;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;

namespace HandIn2._2.Repositories
{
    public interface IAddressRepo : IGenericRepo<Address>
    {
        List<Address> GetAllAddresses();
        List<Address> GetAddressListByContact(Contact c);
        Address CheckExisting(Address adress);
    }
}