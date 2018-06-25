namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvatarAndThumbnail_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "AvatarThumbnailPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AvatarThumbnailPath");
            DropColumn("dbo.AspNetUsers", "AvatarPath");
        }
    }
}
