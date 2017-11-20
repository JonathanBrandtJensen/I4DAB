using System;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;

namespace HandIn2._2
{
	public class ContactMenu
	{
		public static void Show(Contact c)
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Contact!");
			Console.WriteLine();
			MenuTextFormatter.PrintContact(c);
			MenuTextFormatter.PrintAddress(c);
			MenuTextFormatter.PrintPhonenumber(c);
			MenuTextFormatter.PrintEmails(c);
			Console.WriteLine("Press E to exit");
			while (Console.ReadLine() != "e")
			{

			}
		}
	}
}