namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_entities___DiseaseComplaint_CommonMedicalRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiseaseComplaints",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Started = c.DateTime(),
                        Description = c.String(),
                        MedicalRecordId = c.String(maxLength: 128),
                        SympthomeId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonMedicalRecords", t => t.MedicalRecordId)
                .ForeignKey("dbo.Sympthomes", t => t.SympthomeId)
                .Index(t => t.MedicalRecordId)
                .Index(t => t.SympthomeId);
            
            CreateTable(
                "dbo.CommonMedicalRecords",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        PatientId = c.String(maxLength: 128),
                        DoctorId = c.String(maxLength: 128),
                        DiseaseId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.DiseaseId);
            
            AddColumn("dbo.MedicalTestReferrals", "CommonMedicalRecord_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MedicalTestResults", "CommonMedicalRecord_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedicalTestReferrals", "CommonMedicalRecord_Id");
            CreateIndex("dbo.MedicalTestResults", "CommonMedicalRecord_Id");
            AddForeignKey("dbo.MedicalTestReferrals", "CommonMedicalRecord_Id", "dbo.CommonMedicalRecords", "Id");
            AddForeignKey("dbo.MedicalTestResults", "CommonMedicalRecord_Id", "dbo.CommonMedicalRecords", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiseaseComplaints", "SympthomeId", "dbo.Sympthomes");
            DropForeignKey("dbo.DiseaseComplaints", "MedicalRecordId", "dbo.CommonMedicalRecords");
            DropForeignKey("dbo.CommonMedicalRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalTestResults", "CommonMedicalRecord_Id", "dbo.CommonMedicalRecords");
            DropForeignKey("dbo.MedicalTestReferrals", "CommonMedicalRecord_Id", "dbo.CommonMedicalRecords");
            DropForeignKey("dbo.CommonMedicalRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.CommonMedicalRecords", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.CommonMedicalRecords", new[] { "DiseaseId" });
            DropIndex("dbo.CommonMedicalRecords", new[] { "DoctorId" });
            DropIndex("dbo.CommonMedicalRecords", new[] { "PatientId" });
            DropIndex("dbo.DiseaseComplaints", new[] { "SympthomeId" });
            DropIndex("dbo.DiseaseComplaints", new[] { "MedicalRecordId" });
            DropIndex("dbo.MedicalTestResults", new[] { "CommonMedicalRecord_Id" });
            DropIndex("dbo.MedicalTestReferrals", new[] { "CommonMedicalRecord_Id" });
            DropColumn("dbo.MedicalTestResults", "CommonMedicalRecord_Id");
            DropColumn("dbo.MedicalTestReferrals", "CommonMedicalRecord_Id");
            DropTable("dbo.CommonMedicalRecords");
            DropTable("dbo.DiseaseComplaints");
        }
    }
}
