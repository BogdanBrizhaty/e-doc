namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdPartyMigrationHistory_Table_Name_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Migrations", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Migrations", "Name");
        }
    }
}
