namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdPartyMigrationHistory_Table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Migrations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        DateExecuted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Migrations");
        }
    }
}
