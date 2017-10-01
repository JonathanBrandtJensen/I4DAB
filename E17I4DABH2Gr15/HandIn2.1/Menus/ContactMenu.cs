using System;
using HandIn2._1.CRUD;

namespace HandIn2._1
{
	public class ContactMenu
	{
		public static void Show(int id, KartotekContext db)
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Contact!");
			Console.WriteLine();
			Contact currentContact = CrudContact.Read(id, db);
			MenuTextFormatter.PrintContact(currentContact);
			MenuTextFormatter.PrintAddress(currentContact);
			MenuTextFormatter.PrintPhonenumber(currentContact);
			MenuTextFormatter.PrintEmails(currentContact);
			Console.WriteLine("Press E to exit");
			while (Console.ReadLine() != "e")
			{

			}
		}
	}
}