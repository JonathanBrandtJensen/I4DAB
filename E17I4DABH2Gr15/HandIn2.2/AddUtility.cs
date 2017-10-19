using System;
using System.CodeDom;
using System.Net;
using HandIn2._2.CRUD;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{
	public class AddUtility
	{

		#region Add Contact
		public static void AddContact(Contact newContact)
		{
			//First name input
			string firstName = null;
			Console.Write("(Required) First name:\t");
			while (String.IsNullOrEmpty(firstName))
			{
				firstName = Console.ReadLine();
			}
			newContact.FirstName = firstName;
			//--------END---------

			//Middle name input
			string middleName = null;
			Console.Write("(Optional) Middle name:\t");
			middleName = Console.ReadLine();
			if (middleName.Length > 0)
			{
				newContact.MiddleName = middleName;
			}
			//--------END---------

			//Last name input
			string lastName = null;
			Console.Write("(Required) Last name:\t");
			while (String.IsNullOrEmpty(lastName))
			{
				lastName = Console.ReadLine();
			}
			newContact.LastName = lastName;
			//--------END---------

			//Person type input
			string personType = null;
			Console.Write("(Required) Type name:\t");
			while (String.IsNullOrEmpty(personType))
			{
				personType = Console.ReadLine();
			}
			newContact.PersonType = personType;
			//--------END---------

			//-------------------------------
			//     Create Document on DB
			//-------------------------------
		}

		#endregion

		#region Add Address

		public static void AddAddress(Contact c)
		{
			Address newAddress = new Address();

			//Add streetname
			Console.Write("Streetname: ");
			string streetName = Console.ReadLine();
			while (String.IsNullOrEmpty(streetName))
			{
				streetName = Console.ReadLine();
			}
			newAddress.Streetname = streetName;
			//--------END---------

			//Add house number
			Console.Write("House number: ");
			string houseNumber = Console.ReadLine();
			while (String.IsNullOrEmpty(houseNumber))
			{
				houseNumber = Console.ReadLine();
			}
			newAddress.HousNr = houseNumber;
			//--------END---------

			//Add Address type
			Console.Write("Address type: ");
			string addressType = Console.ReadLine();
			while (String.IsNullOrEmpty(addressType))
			{
				addressType = Console.ReadLine();
			}
			newAddress.AddressType = addressType;
			//--------END---------

			//Add postcode if not exists, then create address document on DB.
			newAddress.PostCodeId = AddPostcode();
			//-------------------------------
			//     Create Document on DB
			//-------------------------------

		}

		#endregion

		#region Add Postcode

		public static string AddPostcode()
		{
			PostCode newPostCode = new PostCode();

			//Add post code
			Console.Write("Post code: ");
			string postCode = Console.ReadLine();
			while (String.IsNullOrEmpty(postCode))
			{
				postCode = Console.ReadLine();
			}
			newPostCode.PostCodeNumber = postCode;
			//--------END---------

			//Add city name
			Console.Write("City name: ");
			string cityName = Console.ReadLine();
			while (String.IsNullOrEmpty(cityName))
			{
				cityName = Console.ReadLine();
			}
			newPostCode.CityName = cityName;
			//--------END---------

			//-------------------------------
			//     Create Document on DB
			//-------------------------------
			//Create if not exists and return PostCodeId
			return CrudPostCode.CreatePostCodeDocumentIfNotExists(databaseName, collectionName, newPostCode);
			
		}

		

		#endregion

		#region Add Telephone

		public static void AddTelephone(Contact c, KartotekContext db)
		{
			Telephone newTelephone = new Telephone();
			//Add phone number
			Console.Write("Phone number: ");
			string phoneNumber = Console.ReadLine();
			while (String.IsNullOrEmpty(phoneNumber))
			{
				phoneNumber = Console.ReadLine();
			}
			newTelephone.TelephoneNr = phoneNumber;
			//--------END---------

			//Add phone type
			Console.Write("Phone type: ");
			string phoneType = Console.ReadLine();
			while (String.IsNullOrEmpty(phoneType))
			{
				phoneType = Console.ReadLine();
			}
			newTelephone.TelephoneType = phoneType;
			//--------END---------

			//Add phone company
			Console.Write("Phone Company: ");
			string phoneCompany = Console.ReadLine();
			while (String.IsNullOrEmpty(phoneCompany))
			{
				phoneCompany = Console.ReadLine();
			}
			newTelephone.PhoneCompany = phoneCompany;
			//--------END---------
			CrudTelephone.Create(c, newTelephone, db);
		}

		#endregion

		#region Add Email

		public static void AddEmail(Contact c)
		{
			Email newEmail = new Email();

			//Add email address
			Console.Write("Email address: ");
			string emailId = Console.ReadLine();
			while (String.IsNullOrEmpty(emailId))
			{
				emailId = Console.ReadLine();
			}
			newEmail.EmailId = emailId;
			//--------END---------

			//Add email type
			Console.Write("Email type: ");
			string emailType = Console.ReadLine();
			while (String.IsNullOrEmpty(emailType))
			{
				emailType = Console.ReadLine();
			}
			newEmail.EmailType = emailType;
			//--------END---------

		}

		#endregion

	}
}