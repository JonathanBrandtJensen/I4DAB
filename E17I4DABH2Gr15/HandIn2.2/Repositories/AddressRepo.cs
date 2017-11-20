using System.Collections.Generic;
using System.Linq;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using Microsoft.Azure.Documents.SystemFunctions;

namespace HandIn2._2.Repositories
{
    public class AddressRepo : GenericRepo<Address>, IAddressRepo
    {
        public AddressRepo(ICRUD<Address> crud) : base(crud)
        {
        }

        public List<Address> GetAllAddresses()
        {
            return _crud.Query().ToList();
        }

        public List<Address> GetAddressListByContact(Contact c)
        {
            return _crud.Query().Where(f => f.ContactIds.Contains(c.Id)).ToList();
        }

        public Address CheckExisting(Address address)
        {
            var queryReturn = _crud.Query().Where(f => f.HousNr == address.HousNr &&
                                     f.Streetname == address.Streetname &&
                                     f.PostCode.PostCodeNumber == address.PostCode.PostCodeNumber &&
                                     f.AddressType == address.AddressType).ToList();
            if (queryReturn.Count == 1)
            {
                return queryReturn.First();
            }
            return null;
        }
    }
}