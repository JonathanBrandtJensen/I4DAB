namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryFixAddICollToAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Contact_PersonId", "dbo.Contacts");
            DropIndex("dbo.Addresses", new[] { "Contact_PersonId" });
            CreateTable(
                "dbo.ContactAddresses",
                c => new
                    {
                        Contact_PersonId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contact_PersonId, t.Address_AddressId })
                .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Contact_PersonId)
                .Index(t => t.Address_AddressId);
            
            DropColumn("dbo.Addresses", "Contact_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Contact_PersonId", c => c.Int());
            DropForeignKey("dbo.ContactAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ContactAddresses", "Contact_PersonId", "dbo.Contacts");
            DropIndex("dbo.ContactAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.ContactAddresses", new[] { "Contact_PersonId" });
            DropTable("dbo.ContactAddresses");
            CreateIndex("dbo.Addresses", "Contact_PersonId");
            AddForeignKey("dbo.Addresses", "Contact_PersonId", "dbo.Contacts", "Contacts");
        }
    }
}
