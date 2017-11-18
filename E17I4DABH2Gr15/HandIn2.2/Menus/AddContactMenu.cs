using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HandIn2._2.CRUD;

namespace HandIn2._2
{
	public class AddContactMenu
	{
		public static void Show()
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Add contact!");
			Console.WriteLine();
			Console.WriteLine("New contact information:");

		    var newAddress = new Address
		    {
		        AddressId = Guid.NewGuid(),
                ContactIds = new List<Guid>()
		    };
		    var newContact = new Contact
		    {
		        ContactId = Guid.NewGuid(),
                AddressIds = new List<Guid>(),
                Telephones = new List<Telephone>(),
                Emails = new List<Email>()
		    };
		    AddUtility.AddContact(newContact);
			AddUtility.AddAddress(newContact, newAddress);
			//Add extra address
			Console.WriteLine("Want to add another address? 'yes' or 'no'");
			string answer = Console.ReadLine();
			if (answer == "yes")
			{
			    var extraNewAddress = new Address
			    {
			        AddressId = Guid.NewGuid()
			    };
                AddUtility.AddAddress(newContact, extraNewAddress);
			}
			else if (answer == "no")
			{
				Console.WriteLine("Moving on.");
			}
			//Add email
			Console.WriteLine("Want to add an email? 'yes' or 'no'");
			answer = Console.ReadLine();
			if (answer == "yes")
			{
				AddUtility.AddEmail(newContact);
			}
			else if (answer == "no")
			{
				Console.WriteLine("Moving on.");
			}
			//Add phone
			Console.WriteLine("Want to add a telephone? 'yes' or 'no'");
			answer = Console.ReadLine();
			if (answer == "yes")
			{
				AddUtility.AddTelephone(newContact);
			}
			else if (answer == "no")
			{
				Console.WriteLine("Moving on.");
			}
		    Address checkExisting = QueryAddress.QueryIfExistingAddress(newAddress);
		    if (checkExisting == null)
		    {
		        CrudContact.CreateContactDocumentIfNotExists(newContact).Wait();
		        CrudAddress.CreateAddressDocumentIfNotExists(newAddress).Wait();
            }
		    else
		    {
		        CrudContact.CreateContactDocumentIfNotExists(newContact).Wait();
            }
		    
        }
	}
}