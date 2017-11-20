using System;
using System.Collections.Generic;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using HandIn2._2.Factory;
using HandIn2._2.Repositories;

namespace HandIn2._2
{
	public class MenuTextFormatter : IMenuTextFormatter
	{
	    private IContactRepo _contactRepo;

        MenuTextFormatter()
	    {
	        _contactRepo = new ContactRepo(new CRUD<Contact>(CosmosConnection.databaseName, CosmosConnection.contactCollection));
	    }
		public void CenteredHeader(string text)
		{
			string headerText = text;
			Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (headerText.Length / 2)) + "}", headerText);
		}
 
		public void MenuItem(string itemName, string text)
		{
			Console.WriteLine("(" + itemName + ")" + "\t " + text);
		}

		public void PrintContact(Contact c)
		{
			if (String.IsNullOrEmpty(c.MiddleName))
			{
				Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.PersonType);
			}
			else
			{
				Console.WriteLine(c.FirstName + "\t" + c.MiddleName + "\t" + c.LastName + "\t" + c.PersonType);
			}
		}

	    public void PrintContact(int key, Contact c)
	    {
	        if (String.IsNullOrEmpty(c.MiddleName))
	        {
	            Console.WriteLine(key + "\t" + c.FirstName + "\t" + c.LastName + "\t" + c.PersonType);
	        }
	        else
	        {
	            Console.WriteLine(key + "\t" + c.FirstName + "\t" + c.MiddleName + "\t" + c.LastName + "\t" + c.PersonType);
	        }
	    }

        public void PrintAddresses(Contact c)
        {
            ICollection<Address> addressCollection = RepoFactory.AddressRepo.GetAddressListByContact(c);
			foreach (Address address in addressCollection)
			{
				Console.WriteLine(address.Streetname + " " + address.HousNr);
				Console.WriteLine(address.PostCode.PostCodeNumber + " " + address.PostCode.CityName);
				Console.WriteLine(address.AddressType);
				Console.WriteLine();
			}
		}

		public void PrintPhonenumber(Contact c)
		{
			Console.WriteLine("Phone numbers:");
			foreach (Telephone telephone in c.Telephones)
			{
				Console.WriteLine(telephone.TelephoneNr + " " + telephone.TelephoneType + " " + telephone.PhoneCompany);
			}
		}

		public void PrintEmails(Contact c)
		{
			Console.WriteLine("Emails:");
			foreach (Email email in c.Emails)
			{
				Console.WriteLine(email.EmailId + " " + email.EmailType);
			}
		}


	}
}