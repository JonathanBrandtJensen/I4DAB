using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    public class Kartotek
    {
    }

    public class KartotekContext : DbContext
    {
        public KartotekContext() : base("name=HandIn2_GR15")
        {

        }

        //public DbSet<Kartotek> Kartoteks { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }
		public DbSet<PostCode> PostCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
	        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
	        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Entity<Contact>()
		        .Property(u => u.PersonId)
		        .HasColumnName("Contacts");
	        modelBuilder.Entity<Address>()
		        .Property(u => u.AddressId)
				.HasColumnName("Addresses");
            modelBuilder.Entity<Email>()
                .Property(u => u.EmailId)
                .HasColumnName("Emails");
	        modelBuilder.Entity<Telephone>()
		        .Property(u => u.TelephoneNr);
            modelBuilder.Entity<PostCode>()
                .Property(u => u.PostCodeId)
                .HasColumnName("PostCodes");
        }
    }
}
