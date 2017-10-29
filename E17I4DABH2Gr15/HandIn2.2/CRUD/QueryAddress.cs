using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
    public class QueryAddress
    {
        public static ICollection<Address> QueryContactAddressCollection(Contact c)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the Andersen family via its LastName
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
    }
}