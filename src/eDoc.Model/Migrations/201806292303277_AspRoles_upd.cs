namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspRoles_upd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetRoles", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetRoles", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "IsDeleted");
            DropColumn("dbo.AspNetRoles", "LastModifiedDate");
            DropColumn("dbo.AspNetRoles", "CreationDate");
        }
    }
}
