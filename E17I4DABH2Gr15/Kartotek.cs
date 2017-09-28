using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    public class Kartotek
    {
        public int KartotekId { get; set; }
        public List<Contact> Contacts { get; set; }
    }

    public class Contact
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonType { get; set; }
        [Required]
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Telephone> Telephones { get; set; }
        public virtual List<Email> Emails { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string AddressType { get; set; }
        [Required]
        public string Streetname { get; set; }
        [Required]
        public int HousNr { get; set; }
        [Required]
        public PostCode PostCode{ get; set; }
        [Required]
        public Contact Contact { get; set; }
    }

    public class PostCode
    {
        public int PostCodeId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }

    }

    public class Telephone
    {
        public int TelephoneNr { get; set; }
        [Required]
        public string TelephoneType { get; set; }
        [Required]
        public string PhoneCompany { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
    }

    public class Email
    {
        public string EmailId { get; set; }
        [Required]
        public  string EmailType { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
    }

    public class KartotekContext : DbContext
    {
        public DbSet<Kartotek> Kartoteks { get; set; }
        public DbSet<Contact> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>()
                .Property(u => u.EmailId)
                .HasColumnName("Email");
            modelBuilder.Entity<PostCode>()
                .Property(u => u.PostCodeId)
                .HasColumnName("PostCode");
        }
    }
}
