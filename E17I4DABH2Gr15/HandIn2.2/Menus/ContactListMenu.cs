using System;
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
			Console.WriteLine("ID\t First name\t Middle name\t Last name\t Type\t");
			Console.WriteLine();
			var contactList = CrudContact.ReadAll();
			foreach (Contact contact in contactList)
			{
				MenuTextFormatter.PrintContact(contact);
			}
			Console.WriteLine("Press E to exit");
		}
	}
}