namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiseaseAndSympthome_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        ICDCode = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseSympthomeMappings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DiseaseId = c.String(maxLength: 128),
                        SympthomeId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId)
                .ForeignKey("dbo.Sympthomes", t => t.SympthomeId)
                .Index(t => t.DiseaseId)
                .Index(t => t.SympthomeId);
            
            CreateTable(
                "dbo.Sympthomes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiseaseSympthomeMappings", "SympthomeId", "dbo.Sympthomes");
            DropForeignKey("dbo.DiseaseSympthomeMappings", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.DiseaseSympthomeMappings", new[] { "SympthomeId" });
            DropIndex("dbo.DiseaseSympthomeMappings", new[] { "DiseaseId" });
            DropTable("dbo.Sympthomes");
            DropTable("dbo.DiseaseSympthomeMappings");
            DropTable("dbo.Diseases");
        }
    }
}
