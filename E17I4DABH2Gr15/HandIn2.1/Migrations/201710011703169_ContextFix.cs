namespace HandIn2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "HouseNr", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "HousNr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "HousNr", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "HouseNr");
        }
    }
}
