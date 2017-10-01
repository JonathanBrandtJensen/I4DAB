using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HandIn2._1.CRUD
{
	public class CrudAddress
	{
		public static void Create(Contact c, Address a, KartotekContext db)
		{
			db.Addresses.Add(a);
			c.Addresses.Add(a);
		}

		public static Address Read(int id, KartotekContext db)
		{
			return db.Addresses.Find(id);
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
			var tmpAddress = db.Addresses.Find(id);
			if (tmpAddress == null)
			{
				Debug.WriteLine("Address did not exist.");
				return;
			}
			db.Addresses.Remove(tmpAddress);
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