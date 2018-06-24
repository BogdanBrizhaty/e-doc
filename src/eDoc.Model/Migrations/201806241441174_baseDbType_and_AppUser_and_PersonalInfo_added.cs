namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseDbType_and_AppUser_and_PersonalInfo_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPersonalInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Patronymic = c.String(),
                        BirthDate = c.DateTime(),
                        Address = c.String(),
                        CellPhone = c.String(),
                        ContactEmail = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastVisitedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPersonalInfoes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserPersonalInfoes", new[] { "Id" });
            DropColumn("dbo.AspNetUsers", "LastVisitedDate");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "LastModifiedDate");
            DropColumn("dbo.AspNetUsers", "CreationDate");
            DropTable("dbo.UserPersonalInfoes");
        }
    }
}
