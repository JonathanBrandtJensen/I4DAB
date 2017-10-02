namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDeletedTables : DbMigration
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

        }
        
        public override void Down()
        {
           
        }
    }
}
