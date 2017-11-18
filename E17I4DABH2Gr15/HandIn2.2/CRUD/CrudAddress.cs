using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
    public class CrudAddress
    {
        public static async Task CreateAddressDocumentIfNotExists(Address o)
        {
            try
            {
                await CosmosConnection.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName,
                    CosmosConnection.addressCollection, o.AddressId.ToString()));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await CosmosConnection.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(CosmosConnection.databaseName,
                        CosmosConnection.addressCollection), o);
                }
                else
                {
                    throw;
                }
            }
        }

        public static async Task ReplaceAddressDocument(Address c)
        {
            try
            {
                await CosmosConnection.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName,
                    CosmosConnection.addressCollection, c.AddressId.ToString()), c);
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

        public static async Task DeleteAddressDocument(Guid addressId)
        {
            try
            {
                await CosmosConnection.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(CosmosConnection.databaseName,
                    CosmosConnection.addressCollection, addressId.ToString()));
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