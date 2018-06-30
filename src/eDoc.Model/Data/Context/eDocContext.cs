using eDoc.Model.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public class EDocContext : ApplicationContextBase
    {
        // migrations
        public DbSet<Migration> ThirdPartyMigrationHistory { get; set; }

        // users
        public DbSet<UserPersonalInfo> UserPersonalInfoes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        // Diseases
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Sympthome> Sympthomes { get; set; }
        public DbSet<DiseaseSympthomeMapping> DiseaseSympthomeMappings { get; set; }

        // Contingent
        public DbSet<Contingent> Contingents { get; set; }

        // medical tests
        public DbSet<MedicalTest> MedicalTests { get; set; }
        public DbSet<MedicalTestResult> MedicalTestResults { get; set; }
        public DbSet<MedicalTestReferral> MedicalTestReferrals { get; set; }

        // medical records
        public DbSet<CommonMedicalRecord> MedicalRecords { get; set; }
        public DbSet<DiseaseComplaint> DiseaseComplaints { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public EDocContext(string connStringName) : base(connStringName)
        {
        }
    }
}
