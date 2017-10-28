using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
    public class QueryContact
    {
        public static ICollection<Contact> QueryContactCollection(string firstname)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the Andersen family via its LastName
            IQueryable<Contact> contactQuery = CosmosConnection.client.CreateDocumentQuery<Contact>(
                    UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName, CosmosConnection.contactCollection), queryOptions)
                .Where(f => f.FirstName == firstname);

            ICollection<Contact> queryCollectinReturn = null;

            if (!contactQuery.Any())
            {
                foreach (Contact contact in contactQuery)
                {
                    queryCollectinReturn.Add(contact);
                }
                return queryCollectinReturn;
            }
            else
            {
                Console.WriteLine("No contacts found.");
                return null;
            }
        }
    }
}