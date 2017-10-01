namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Addresses = c.Int(nullable: false, identity: true),
                        AddressType = c.String(nullable: false),
                        Streetname = c.String(nullable: false),
                        HousNr = c.Int(nullable: false),
                        Contact_PersonId = c.Int(nullable: false),
                        PostCode_PostCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Addresses)
                .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
                .ForeignKey("dbo.PostCodes", t => t.PostCode_PostCodeId)
                .Index(t => t.Contact_PersonId)
                .Index(t => t.PostCode_PostCodeId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Contacts = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        PersonType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Contacts);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Emails = c.String(nullable: false, maxLength: 128),
                        EmailType = c.String(nullable: false),
                        Contact_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Emails)
                .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
                .Index(t => t.Contact_PersonId);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        TelephoneNr = c.Int(nullable: false, identity: true),
                        TelephoneType = c.String(nullable: false),
                        PhoneCompany = c.String(nullable: false),
                        Contact_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TelephoneNr)
                .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
                .Index(t => t.Contact_PersonId);
            
            CreateTable(
                "dbo.PostCodes",
                c => new
                    {
                        PostCodes = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        Contact_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostCodes)
                .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
                .Index(t => t.Contact_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "PostCode_PostCodeId", "dbo.PostCodes");
            DropForeignKey("dbo.PostCodes", "Contact_PersonId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "Contact_PersonId", "dbo.Contacts");
            DropForeignKey("dbo.Telephones", "Contact_PersonId", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "Contact_PersonId", "dbo.Contacts");
            DropIndex("dbo.PostCodes", new[] { "Contact_PersonId" });
            DropIndex("dbo.Telephones", new[] { "Contact_PersonId" });
            DropIndex("dbo.Emails", new[] { "Contact_PersonId" });
            DropIndex("dbo.Addresses", new[] { "PostCode_PostCodeId" });
            DropIndex("dbo.Addresses", new[] { "Contact_PersonId" });
            DropTable("dbo.PostCodes");
            DropTable("dbo.Telephones");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
