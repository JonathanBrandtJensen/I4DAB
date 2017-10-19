using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
	public class CrudPostCode
	{
		public static string CreatePostCodeDocumentIfNotExists(DocumentClient client, string databaseName, string collectionName, PostCode postCode)
		{
			try
			{
				client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, postCode.PostCodeId));
				return null;
			}
			catch (DocumentClientException de)
			{
				if (de.StatusCode == HttpStatusCode.NotFound)
				{
					client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), postCode);
					return null;
				}
				else
				{
					throw;
				}
			}
		}

		public static void DeletePostCodeDocumentIfNotInUse()
		{
			
		}
	}
}