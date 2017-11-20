using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HandIn2._2.Collections;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2.CRUD
{
    public class CRUD<T> : ICRUD<T> where T : class, IHasIdentifier
    {
        private readonly string _databaseId;
        private readonly string _collectionId;

        public CRUD(string databaseId, string collectionId)
        {
            _databaseId = databaseId;
            _collectionId = collectionId;
        }

        public async Task<string> CreateDocument(T objectToCreate)
        {
            var documentRespons = await CosmosConnection.Client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_databaseId,
                    _collectionId), objectToCreate);
            return documentRespons.Resource.Id;
        }

        public async Task<bool> DeleteDocument(Guid objectToDelete)
        {
            try
            {
                await CosmosConnection.Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseId,
                    _collectionId, objectToDelete.ToString()));
                return true;
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine(de);
                    Debug.WriteLine("Not found.");
                }
                else
                {
                    Debug.WriteLine(de);
                }
                return false;
            }
        }

        public IOrderedQueryable<T> Query()
        {
            FeedOptions queryOptions = new FeedOptions() { MaxItemCount = -1 };
            return CosmosConnection.Client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), queryOptions);
        }

        public async Task<T> ReadDocument(Guid idOfObject)
        {
            try
            {
                var documentResponse = await CosmosConnection.Client.ReadDocumentAsync<T>(UriFactory.CreateDocumentUri(
                    _databaseId, _collectionId, idOfObject.ToString()));
                return documentResponse.Document;
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine("Not found.");
                }
                return null;
            }
        }

        public async Task<bool> ReplaceDocument(T objectToReplace)
        {
            try
            {
                await CosmosConnection.Client.ReplaceDocumentAsync(
                    UriFactory.CreateDocumentUri(_databaseId, _collectionId, objectToReplace.Id.ToString()), objectToReplace);
                return true;
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    Debug.WriteLine(de);
                    Debug.WriteLine("Not found.");
                }
                else
                {
                    Debug.WriteLine(de);
                }
                return false;
            }
        }
    }
}