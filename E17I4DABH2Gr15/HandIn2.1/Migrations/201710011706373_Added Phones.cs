namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhones : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Telephones", name: "TelephoneNr", newName: "" +
                                                                                "PhoneNumbers" +
                                                                                "" +
                                                                                "");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Telephones", name: "PhoneNumbers", newName: "TelephoneNr");
        }
    }
}
