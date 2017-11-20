using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using HandIn2._2.Factory;
using HandIn2._2.Repositories;
using Microsoft.Azure.Documents;

namespace HandIn2._2
{
	class DocDB
	{
	    static void Main(string[] args)
	    {
			IContactRepo ContactRepo = new ContactRepo(new CRUD<Contact>(CosmosConnection.databaseName, CosmosConnection.contactCollection));
            IAddressRepo AddressRepo = new AddressRepo(new CRUD<Address>(CosmosConnection.databaseName, CosmosConnection.addressCollection));
	        while (true)
	        {
	            
	        }
		}
	}
}
