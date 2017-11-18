using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.SystemFunctions;

namespace HandIn2._2.CRUD
{
    public class QueryAddress
    {
        public static ICollection<Address> QueryContactAddressCollection(Contact c)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<Address> addressQuery = CosmosConnection.client.CreateDocumentQuery<Address>(
                    UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName, CosmosConnection.addressCollection), queryOptions)
                .Where(f => f.ContactIds.Contains(c.ContactId));

            ICollection<Address> queryCollectionReturn = new List<Address>();

            if (addressQuery.Count() > 0)
            {
                foreach (Address address in addressQuery)
                {
                    queryCollectionReturn.Add(address);
                }
                return queryCollectionReturn;
            }
            else
            {
                Console.WriteLine("No contacts found.");
                return null;
            }
        }

        public static Address QueryIfExistingAddress(Address a)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<Address> addressQuery = CosmosConnection.client.CreateDocumentQuery<Address>(
                    UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName, CosmosConnection.addressCollection), queryOptions)
                .Where(f => f.Streetname == a.Streetname && f.HousNr == a.HousNr && f.PostCode.CityName == a.PostCode.CityName && f.PostCode.PostCodeNumber == a.PostCode.PostCodeNumber);

            List<Address> returnList = new List<Address>();
            foreach (Address address in addressQuery)
            {
                returnList.Add(address);
            }

            if (returnList.Count == 0)
            {
                return null;
            }
            return returnList.First();
        }
    }
}