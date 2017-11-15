namespace Handin3._2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KartotekContext : DbContext
    {
        public KartotekContext()
            : base("name=KartotekContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<PostCode> PostCodes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Contacts)
                .WithMany(e => e.Addresses)
                .Map(m => m.ToTable("ContactAddresses").MapLeftKey("Address_AddressId").MapRightKey("Contact_PersonId"));

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Emails)
                .WithRequired(e => e.Contact)
                .HasForeignKey(e => e.Contact_PersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Telephones)
                .WithRequired(e => e.Contact)
                .HasForeignKey(e => e.Contact_PersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostCode>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.PostCode)
                .HasForeignKey(e => e.PostCode_PostCodeId)
                .WillCascadeOnDelete(false);
        }
    }
}
