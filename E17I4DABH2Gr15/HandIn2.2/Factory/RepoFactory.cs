using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using HandIn2._2.Repositories;

namespace HandIn2._2.Factory
{
    public class RepoFactory : IRepoFactory
    {
        private IContactRepo _contactRepo;
        IContactRepo IRepoFactory.ContactRepo => _contactRepo ?? (_contactRepo =
                                                     new ContactRepo(new CRUD<Contact>(CosmosConnection.databaseName,
                                                         CosmosConnection.contactCollection)));

        private IAddressRepo _addressRepo;

        IAddressRepo IRepoFactory.AddressRepo => _addressRepo ?? (_addressRepo =
                                                     new AddressRepo(new CRUD<Address>(CosmosConnection.databaseName,
                                                         CosmosConnection.addressCollection)));
    }
}