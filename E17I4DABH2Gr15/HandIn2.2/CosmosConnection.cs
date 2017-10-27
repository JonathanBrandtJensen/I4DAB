using System;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{
    public class CosmosConnection
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public static DocumentClient client;
        public const string databaseName = "KartotekDB";
        public const string contactCollection = "ContactCollection";
        public const string addressCollection = "AddressCollection";

        private static readonly CosmosConnection instance = new CosmosConnection();

        static CosmosConnection()
        {
            
        }

        private CosmosConnection()
        {
            var databaseUri = UriFactory.CreateDatabaseUri("KartotekDB");

            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database() { Id = databaseName });
            client.CreateDocumentCollectionIfNotExistsAsync(databaseUri,
                new DocumentCollection { Id = contactCollection });
            client.CreateDocumentCollectionIfNotExistsAsync(databaseUri,
                new DocumentCollection { Id = addressCollection });
        }

        /*
        public static CosmosConnection GetDatabase()
        {
            return instance ?? (instance = new CosmosConnection());
        }

        private static CosmosConnection instance;
        */

        public static CosmosConnection Instance
        {
            get { return instance; }
        }
    }
}