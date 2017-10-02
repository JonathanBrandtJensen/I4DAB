namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryAgain : DbMigration
    {
        public override void Up()
        {
	        CreateTable(
			        "dbo.Telephones",
			        c => new
			        {
				        TelephoneNr = c.String(nullable: false, maxLength: 128),
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
				        PostCodes = c.String(nullable: false, maxLength: 128),
				        CityName = c.String(nullable: false),
				        Contact_PersonId = c.Int(nullable: false),
			        })
		        .PrimaryKey(t => t.PostCodes)
		        .ForeignKey("dbo.Contacts", t => t.Contact_PersonId)
		        .Index(t => t.Contact_PersonId);

			DropForeignKey("dbo.Addresses", "PostCode_PostCodeId", "dbo.PostCodes");
            DropIndex("dbo.Addresses", new[] { "PostCode_PostCodeId" });
            RenameColumn(table: "dbo.Telephones", name: "PhoneNumbers", newName: "TelephoneNr");
            DropPrimaryKey("dbo.Telephones");
            DropPrimaryKey("dbo.PostCodes");
            AlterColumn("dbo.Addresses", "PostCode_PostCodeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Telephones", "TelephoneNr", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PostCodes", "PostCodes", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Telephones", "TelephoneNr");
            AddPrimaryKey("dbo.PostCodes", "PostCodes");
            CreateIndex("dbo.Addresses", "PostCode_PostCodeId");
            AddForeignKey("dbo.Addresses", "PostCode_PostCodeId", "dbo.PostCodes", "PostCodes");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "PostCode_PostCodeId", "dbo.PostCodes");
            DropIndex("dbo.Addresses", new[] { "PostCode_PostCodeId" });
            DropPrimaryKey("dbo.PostCodes");
            DropPrimaryKey("dbo.Telephones");
            AlterColumn("dbo.PostCodes", "PostCodes", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Telephones", "TelephoneNr", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Addresses", "PostCode_PostCodeId", c => c.Int());
            AddPrimaryKey("dbo.PostCodes", "PostCodes");
            AddPrimaryKey("dbo.Telephones", "PhoneNumbers");
            RenameColumn(table: "dbo.Telephones", name: "TelephoneNr", newName: "PhoneNumbers");
            CreateIndex("dbo.Addresses", "PostCode_PostCodeId");
            AddForeignKey("dbo.Addresses", "PostCode_PostCodeId", "dbo.PostCodes", "PostCodes");
        }
    }
}
