namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfo_changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPersonalInfoes", "RegistrationAddress", c => c.String());
            AddColumn("dbo.UserPersonalInfoes", "CurrentAddress", c => c.String());
            DropColumn("dbo.UserPersonalInfoes", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPersonalInfoes", "Address", c => c.String());
            DropColumn("dbo.UserPersonalInfoes", "CurrentAddress");
            DropColumn("dbo.UserPersonalInfoes", "RegistrationAddress");
        }
    }
}
