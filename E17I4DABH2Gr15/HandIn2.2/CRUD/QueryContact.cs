using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
    public class QueryContact
    {
        public static Dictionary<int, Contact> QueryContactCollection(string firstname)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<Contact> contactQuery = CosmosConnection.client.CreateDocumentQuery<Contact>(
                    UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName, CosmosConnection.contactCollection), queryOptions)
                .Where(f => f.FirstName.ToLower().Contains(firstname.ToLower()));

            Dictionary<int, Contact> queryCollectinReturn = new Dictionary<int, Contact>();

            if (contactQuery.Count() > 0)
            {
                int keyCount = 0;
                foreach (Contact contact in contactQuery)
                {
                    queryCollectinReturn.Add(++keyCount, contact);
                }
                return queryCollectinReturn;
            }
            else
            {
                Console.WriteLine("No contacts found.");
                return null;
            }
        }

        public static ICollection<Contact> QuerySimpleContactCollection()
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<Contact> contactQuery = CosmosConnection.client.CreateDocumentQuery<Contact>(
                UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName,
                    CosmosConnection.contactCollection), queryOptions);

            ICollection<Contact> returnCollection = new List<Contact>();
            foreach (Contact contact in contactQuery)
            {
                returnCollection.Add(contact);
            }
            return returnCollection;
        }
    }
}