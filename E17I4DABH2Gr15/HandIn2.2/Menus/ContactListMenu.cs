using System;
using System.Collections.Generic;
using System.Linq;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using HandIn2._2.Factory;

namespace HandIn2._2
{
	public class ContactListMenu
	{
	    public IRepoFactory RepoFactory = new RepoFactory();
        public void Show()
		{
			Console.Clear();
			MenuTextFormatter.CenteredHeader("Contact list!");
			Console.WriteLine();
			Console.WriteLine("First name\t Middle name\t Last name\t Type\t");
			Console.WriteLine();
		    List<Contact> contactList = RepoFactory.ContactRepo.GetAllContacts();
		    var sortedList = contactList.OrderBy(f => f.FirstName);
			foreach (Contact contact in sortedList)
			{
				MenuTextFormatter.PrintContact(contact);
			}
			Console.WriteLine("Press E to exit");
		}
	}
}