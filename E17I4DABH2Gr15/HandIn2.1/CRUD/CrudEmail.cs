using System;
using System.Diagnostics;

namespace HandIn2._1.CRUD
{
	public class CrudEmail
	{
		public static void Create(Contact c, Email email, KartotekContext db)
		{
			db.Emails.Add(email);
			c.Emails.Add(email);
		}

		public static Email Read(int id, KartotekContext db)
		{
			return db.Emails.Find(id);
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
			var tmpEmail = db.Emails.Find(id);
			if (tmpEmail == null)
			{
				Debug.WriteLine("Email did not exist.");
				return;
			}
			db.Emails.Remove(tmpEmail);
			try
			{
				db.SaveChanges();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}
	}
}