namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryFixedHouseNr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostCodes", "Contact_PersonId", "dbo.Contacts");
            DropIndex("dbo.Addresses", new[] { "Contact_PersonId" });
            DropIndex("dbo.Addresses", new[] { "PostCode_PostCodeId" });
            DropIndex("dbo.Telephones", new[] { "Contact_PersonId" });
            DropIndex("dbo.PostCodes", new[] { "Contact_PersonId" });
            AddColumn("dbo.Addresses", "HousNr", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Contact_PersonId", c => c.Int());
            AlterColumn("dbo.Addresses", "PostCode_PostCodeId", c => c.Int());
            AlterColumn("dbo.Telephones", "Contact_PersonId", c => c.Int());
            CreateIndex("dbo.Addresses", "Contact_PersonId");
            CreateIndex("dbo.Addresses", "PostCode_PostCodeId");
            CreateIndex("dbo.Telephones", "Contact_PersonId");
            DropColumn("dbo.Addresses", "HouseNr");
            DropColumn("dbo.PostCodes", "Contact_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCodes", "Contact_PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "HouseNr", c => c.Int(nullable: false));
            DropIndex("dbo.Telephones", new[] { "Contact_PersonId" });
            DropIndex("dbo.Addresses", new[] { "PostCode_PostCodeId" });
            DropIndex("dbo.Addresses", new[] { "Contact_PersonId" });
            AlterColumn("dbo.Telephones", "Contact_PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "PostCode_PostCodeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Contact_PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "HousNr");
            CreateIndex("dbo.PostCodes", "Contact_PersonId");
            CreateIndex("dbo.Telephones", "Contact_PersonId");
            CreateIndex("dbo.Addresses", "PostCode_PostCodeId");
            CreateIndex("dbo.Addresses", "Contact_PersonId");
            AddForeignKey("dbo.PostCodes", "Contact_PersonId", "dbo.Contacts", "Contacts");
        }
    }
}
