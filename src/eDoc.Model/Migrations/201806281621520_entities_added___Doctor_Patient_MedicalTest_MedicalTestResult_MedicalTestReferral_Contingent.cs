namespace eDoc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entities_added___Doctor_Patient_MedicalTest_MedicalTestResult_MedicalTestReferral_Contingent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contingents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LastVisit = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        WorkPlace = c.String(),
                        PrivilegeCertificateNo = c.String(),
                        BirthPlace = c.String(),
                        UserPersonalInfoId = c.String(maxLength: 128),
                        ContingentId = c.String(maxLength: 128),
                        DoctorId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contingents", t => t.ContingentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.UserPersonalInfoes", t => t.UserPersonalInfoId)
                .Index(t => t.UserPersonalInfoId)
                .Index(t => t.ContingentId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Workplace = c.String(),
                        Bio = c.String(),
                        WorkingExp = c.Int(nullable: false),
                        SpecializationCode = c.Int(nullable: false),
                        UserPersonalInfoId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserPersonalInfoes", t => t.UserPersonalInfoId)
                .Index(t => t.UserPersonalInfoId);
            
            CreateTable(
                "dbo.MedicalTestReferrals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ExecutionDate = c.DateTime(),
                        ReasonDescription = c.String(),
                        DoctorId = c.String(maxLength: 128),
                        MedicalTestId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.MedicalTests", t => t.MedicalTestId)
                .ForeignKey("dbo.MedicalTestResults", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicalTestId);
            
            CreateTable(
                "dbo.MedicalTests",
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
            
            CreateTable(
                "dbo.MedicalTestResults",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DatePerformed = c.DateTime(),
                        ResultStamp = c.Int(nullable: false),
                        Summary = c.String(),
                        Details = c.String(),
                        PatientId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.MedicalTestReferralPatients",
                c => new
                    {
                        MedicalTestReferral_Id = c.String(nullable: false, maxLength: 128),
                        Patient_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MedicalTestReferral_Id, t.Patient_Id })
                .ForeignKey("dbo.MedicalTestReferrals", t => t.MedicalTestReferral_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.MedicalTestReferral_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "UserPersonalInfoId", "dbo.UserPersonalInfoes");
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserPersonalInfoId", "dbo.UserPersonalInfoes");
            DropForeignKey("dbo.MedicalTestReferralPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.MedicalTestReferralPatients", "MedicalTestReferral_Id", "dbo.MedicalTestReferrals");
            DropForeignKey("dbo.MedicalTestReferrals", "Id", "dbo.MedicalTestResults");
            DropForeignKey("dbo.MedicalTestResults", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalTestReferrals", "MedicalTestId", "dbo.MedicalTests");
            DropForeignKey("dbo.MedicalTestReferrals", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Patients", "ContingentId", "dbo.Contingents");
            DropIndex("dbo.MedicalTestReferralPatients", new[] { "Patient_Id" });
            DropIndex("dbo.MedicalTestReferralPatients", new[] { "MedicalTestReferral_Id" });
            DropIndex("dbo.MedicalTestResults", new[] { "PatientId" });
            DropIndex("dbo.MedicalTestReferrals", new[] { "MedicalTestId" });
            DropIndex("dbo.MedicalTestReferrals", new[] { "DoctorId" });
            DropIndex("dbo.MedicalTestReferrals", new[] { "Id" });
            DropIndex("dbo.Doctors", new[] { "UserPersonalInfoId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropIndex("dbo.Patients", new[] { "ContingentId" });
            DropIndex("dbo.Patients", new[] { "UserPersonalInfoId" });
            DropTable("dbo.MedicalTestReferralPatients");
            DropTable("dbo.MedicalTestResults");
            DropTable("dbo.MedicalTests");
            DropTable("dbo.MedicalTestReferrals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.Contingents");
        }
    }
}
