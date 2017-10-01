using System;
using System.Diagnostics;

namespace HandIn2._1.CRUD
{
	public class CrudTelephone
	{
		public static void Create(Contact c, Telephone t, KartotekContext db)
		{
			db.Telephones.Add(t);
			c.Telephones.Add(t);
		}

		public static Telephone Read(int id, KartotekContext db)
		{
			return db.Telephones.Find(id);
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
			var tmpTelephone = db.Telephones.Find(id);
			if (tmpTelephone == null)
			{
				Debug.WriteLine("Telephone did not exist.");
				return;
			}
			db.Telephones.Remove(tmpTelephone);
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