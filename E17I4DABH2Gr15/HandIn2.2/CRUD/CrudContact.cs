using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
	public class CrudContact
	{
		public static async Task CreateContactDocumentIfNotExists(Contact o)
		{
			try
			{
                await CosmosConnection.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName,
                    CosmosConnection.contactCollection, o.ContactId.ToString()));
			}
			catch (DocumentClientException de)
			{
				if (de.StatusCode == HttpStatusCode.NotFound)
				{
					await CosmosConnection.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName,
                        CosmosConnection.contactCollection), o);
				}
				else
				{
					throw;
				}
			}
		}

        public static async Task ReplaceContactDocument(Contact c)
	    {
	        try
	        {
	            await CosmosConnection.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName, CosmosConnection.contactCollection, c.ContactId.ToString()), c);
            }
	        catch (DocumentClientException de)
	        {
	            if (de.StatusCode == HttpStatusCode.NotFound)
	            {
	                Debug.WriteLine(de);
                    Console.WriteLine("Not found.");
                }
	            else
	            {
	                Debug.WriteLine(de);
                }
	        }
	    }

		public static async Task DeleteContactDocument(Guid contactId)
		{
		    try
		    {
		        await CosmosConnection.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName,
		            CosmosConnection.contactCollection, contactId.ToString()));
		    }
		    catch (DocumentClientException de)
		    {
		        if (de.StatusCode == HttpStatusCode.NotFound)
		        {
		            Debug.WriteLine(de);
                    Console.WriteLine("Not found.");
                }
		        else
		        {
		            Console.WriteLine(de);
                }
		    }
		}
	}
}