using System.Collections.Generic;
using System.Linq;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;

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
    }
}