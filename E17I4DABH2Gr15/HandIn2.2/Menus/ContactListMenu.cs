using System;
using System.Collections.Generic;
using System.Linq;
using HandIn2._2.CRUD;

namespace HandIn2._2
{
	public class ContactListMenu
	{
		public static void Show()
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Contact list!");
			Console.WriteLine();
			Console.WriteLine("First name\t Middle name\t Last name\t Type\t");
			Console.WriteLine();
		    List<Contact> contactList = QueryContact.QuerySimpleContactCollection().ToList();
		    var sortedList = contactList.OrderBy(f => f.FirstName);
			foreach (Contact contact in sortedList)
			{
				MenuTextFormatter.PrintContact(contact);
			}
			Console.WriteLine("Press E to exit");
		}
	}
}