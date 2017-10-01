using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HandIn2._1.CRUD
{
	public class CrudContact
	{
		public static void Create(Contact o, KartotekContext db)
		{
			db.Contacts.Add(o);
		}

		public static Contact Read(int id, KartotekContext db)
		{
			return db.Contacts.Find(id);
		}

		public static void Update(KartotekContext db)
		{
			try
			{
				db.SaveChanges();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		public static void Delete(int id, KartotekContext db)
		{
			var tmpContact = db.Contacts.Find(id);
			if (tmpContact == null)
			{
				Debug.WriteLine("Contact does not exist.");
				return;
			}
			db.Contacts.Remove(tmpContact);
			Update(db);
		}

		public static List<Contact> ReadAll()
		{
			using (var db = new KartotekContext())
			{
				return db.Contacts.ToList();
			}
		}
	}
}