using System;
using System.Collections.Generic;
using System.Linq;
using HandIn2._2.CRUD;

namespace HandIn2._2
{
	public class SearchContactMenu
	{
		public static void Show()
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Search and modify contacts!");
			Console.WriteLine();
			Console.Write("Search parameter: ");
			string searchParam = Console.ReadLine();
			using (var db = new KartotekContext())
			{
				IEnumerable<Contact> searchList = Search(searchParam, db);
				foreach (Contact contact in searchList)
				{
					MenuTextFormatter.PrintContact(contact);
				}

				Console.Write("Enter ID of contact to modify, delete or show: ");
				string modId = Console.ReadLine();
				Console.WriteLine("Write 'm' for Modify, 'd' for Delete or 's' for show");
				string modAction;
				modAction = Console.ReadLine();
				if (modAction == "m")
				{
					if (string.IsNullOrEmpty(modId))
					{
						return;
					}
					Contact modContact = CrudContact.Read(int.Parse(modId), db);
					ModifyContact(modContact);
					CrudContact.Update(db);
				}
				else if (modAction == "d")
				{
				    CrudContact.DeleteContactDocument().Wait();
				}
				else if (modAction == "s")
				{
					ContactMenu.Show(int.Parse(modId), db);
				}
				else
				{
					Console.WriteLine("'m', 'd' or 's' please.");
				}
			}
		}
		public static IEnumerable<Contact> Search(string name)
		{
			return db.Contacts.Where(x => x.FirstName.Contains(name));
		}

		/// <summary>
		/// Modifies a Contact object
		/// </summary>
		/// <param name="c"></param>
		private static void ModifyContact(Contact c)
		{
			//First name input
			string firstName = null;
			Console.Write("(Required) First name:\t");
			firstName = Console.ReadLine();
			if (String.IsNullOrEmpty(firstName))
			{
			}
			else
			{
				c.FirstName = firstName;
			}
			//--------END---------

			//Middle name input
			string middleName = null;
			Console.Write("(Optional) Middle name:\t");
			middleName = Console.ReadLine();
			if (string.IsNullOrEmpty(middleName))
			{
			}
			else
			{
				c.MiddleName = middleName;
			}
			//--------END---------

			//Last name input
			string lastName = null;
			Console.Write("(Required) Last name:\t");
			lastName = Console.ReadLine();
			if (String.IsNullOrEmpty(lastName))
			{
			}
			else
			{
				c.LastName = lastName;
			}
			//--------END---------

			//Person type input
			string personType = null;
			Console.Write("(Required) Type name:\t");
			personType = Console.ReadLine();
			if (String.IsNullOrEmpty(personType))
			{
			}
			else
			{
				c.PersonType = personType;
			}
			//--------END---------
		}
	}
}