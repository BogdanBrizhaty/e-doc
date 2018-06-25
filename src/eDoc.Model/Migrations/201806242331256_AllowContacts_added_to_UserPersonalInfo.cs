namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowContacts_added_to_UserPersonalInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPersonalInfoes", "AllowToCall", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserPersonalInfoes", "AllowToSMS", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserPersonalInfoes", "AllowEmailingMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPersonalInfoes", "AllowEmailingMe");
            DropColumn("dbo.UserPersonalInfoes", "AllowToSMS");
            DropColumn("dbo.UserPersonalInfoes", "AllowToCall");
        }
    }
}
