using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{
    public class CosmosConnection
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public static DocumentClient Client;
        public const string databaseName = "KartotekDB";
        public const string contactCollection = "ContactCollection";
        public const string addressCollection = "AddressCollection";

        #region Thread safe singleton Imeplementation

        static CosmosConnection()
        {
            StartUp().Wait();
        }

        private CosmosConnection()
        {
            
        }

        public static CosmosConnection Instance { get; } = new CosmosConnection();

        #endregion

        public static async Task StartUp()
        {
            var databaseUri = UriFactory.CreateDatabaseUri("KartotekDB");

            Client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            Client.CreateDatabaseIfNotExistsAsync(new Database() { Id = databaseName }).Wait();
            Client.CreateDocumentCollectionIfNotExistsAsync(databaseUri,
                new DocumentCollection { Id = contactCollection }).Wait();
            Client.CreateDocumentCollectionIfNotExistsAsync(databaseUri,
                new DocumentCollection { Id = addressCollection }).Wait();
        }
    }
}