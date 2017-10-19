using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

//Skal vi have ID eller skal postnummeret være ID?
//Skal vi selv sætte et ID samtidig, eller skal vi lave en auto incrementer?
//Arrays til embed/reference, eller ICollections for at være generic?

namespace HandIn2._2
{
	class Program
	{
		public const string EndpointUrl = "https://localhost:8081";
		public const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

		static void Main(string[] args)
		{
			DocumentClient client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
			client.CreateDatabaseIfNotExistsAsync(new Database() { Id = "KartotekDB" });
			client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("KartotekDB"),
				new DocumentCollection { Id = "ContactCollection" });
			client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("KartotekDB"),
				new DocumentCollection { Id = "AddressCollection" });
			client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("KartotekDB"),
				new DocumentCollection { Id = "EmailCollection" });
			client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("KartotekDB"),
				new DocumentCollection { Id = "PostCodeCollection" });
			client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("KartotekDB"),
				new DocumentCollection { Id = "TelephoneCollection" });

			int key = 0;
			while (key != 9)
			{
				MainMenu.Show();
				key = 0;
				string keyStr = Console.ReadLine();
				key = int.Parse(keyStr);

				switch (key)
				{
					case 1:
					{
						ContactListMenu.Show();
						while (Console.ReadLine() != "e")
						{

						}
						break;
					}

					case 2:
					{
						SearchContactMenu.Show();
						break;
					}

					case 3:
					{
						AddContactMenu.Show();
						break;
					}

					case 9:
						break;

					default:
						break;
				}
			}
		}
	}
}
