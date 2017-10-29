﻿using System;
using System.Collections.Generic;
using HandIn2._2.CRUD;

namespace HandIn2._2
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
				Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.PersonType);
			}
			else
			{
				Console.WriteLine(c.FirstName + "\t" + c.MiddleName + "\t" + c.LastName + "\t" + c.PersonType);
			}
		}

	    public static void PrintContact(int key, Contact c)
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

        public static void PrintAddress(Contact c)
        {
            ICollection<Address> addressCollection = QueryAddress.QueryContactAddressCollection(c);
			foreach (Address address in addressCollection)
			{
				Console.WriteLine(address.Streetname + " " + address.HousNr);
				Console.WriteLine(address.PostCode.PostCodeNumber + " " + address.PostCode.CityName);
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