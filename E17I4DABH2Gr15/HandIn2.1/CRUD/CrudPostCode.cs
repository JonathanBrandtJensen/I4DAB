using System;
using System.Diagnostics;

namespace HandIn2._1.CRUD
{
	public class CrudPostCode
	{
		public static void Create(Address a, PostCode p, KartotekContext db)
		{
			PostCode tmpPostCode = db.PostCodes.Find(p.PostCodeId);
			if (p.PostCodeId == tmpPostCode?.PostCodeId)
			{
				p.Address.Add(a);
				Console.WriteLine("Postcode already exists.");
				return;
			}
			db.PostCodes.Add(p);
			p.Address.Add(a);
		}

		public static PostCode Read(int id, KartotekContext db)
		{
			return db.PostCodes.Find(id);
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
			var tmpPostCode = db.PostCodes.Find(id);
			if (tmpPostCode == null)
			{
				Debug.WriteLine("Postcode did not exist.");
				return;
			}
			db.PostCodes.Remove(tmpPostCode);
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