namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppRole_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Role");
        }
    }
}
