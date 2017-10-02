using System;

namespace HandIn2._1
{
	public class MenuTextFormatter
	{
		public static void CenteredHeader(string text)
		{
			string headerText = text;
			Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (headerText.Length / 2)) + "}", headerText);
		}

		public static void MenuItem(string ItemName, string text)
		{
			Console.WriteLine("(" + ItemName + ")" + "\t " + text);
		}

		public static void PrintContact(Contact c)
		{
			if (String.IsNullOrEmpty(c.MiddleName))
			{
				Console.WriteLine(c.PersonId + "\t" + c.FirstName + "\t" + c.LastName + "\t" + c.PersonType);
			}
			else
			{
				Console.WriteLine(c.PersonId + "\t" + c.FirstName + "\t" + c.MiddleName + "\t" + c.LastName + "\t" + c.PersonType);
			}
			
		}

		public static void PrintAddress(Contact c)
		{
			foreach (Address address in c.Addresses)
			{
				Console.WriteLine(address.Streetname + " " + address.HousNr);
				Console.WriteLine(address.PostCode.PostCodeId + " " + address.PostCode.CityName);
				Console.WriteLine(address.AddressType);
				Console.WriteLine();
			}
		}

		public static void PrintPhonenumber(Contact c)
		{
			Console.WriteLine("Phone numbers:");
			foreach (Telephone telephone in c.Telephones)
			{
				Console.WriteLine(telephone.TelephoneNr + " " + telephone.TelephoneType + " " + telephone.PhoneCompany);
			}
		}

		public static void PrintEmails(Contact c)
		{
			Console.WriteLine("Emails:");
			foreach (Email email in c.Emails)
			{
				Console.WriteLine(email.EmailId + " " + email.EmailType);
			}
		}
	}
}