using System;
using System.Diagnostics;
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

			var newContact = new Contact();
			AddUtility.AddContact(newContact);
			AddUtility.AddAddress(newContact);
			//Add extra address
			Console.WriteLine("Want to add another address? 'yes' or 'no'");
			string answer = Console.ReadLine();
			if (answer == "yes")
			{
				AddUtility.AddAddress(newContact, db);
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
				AddUtility.AddEmail(newContact, db);
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
				AddUtility.AddTelephone(newContact, db);
			}
			else if (answer == "no")
			{
				Console.WriteLine("Moving on.");
			}
			CrudContact.Update(db);
		}
	}
}