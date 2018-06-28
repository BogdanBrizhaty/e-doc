using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public enum Gender
    {
        Female,
        Male
    }
    public class Patient : DbEntityBase
    {
        // self properties
        public DateTime? LastVisit { get; set; }
        public int Gender { get; set; }
        public string WorkPlace { get; set; }
        public string PrivilegeCertificateNo { get; set; }
        public string BirthPlace { get; set; }

        // foreign keys
        [ForeignKey("UserPersonalInfo")]
        public string UserPersonalInfoId { get; set; }
        [ForeignKey("Contingent")]
        public string ContingentId { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        // navigation properties
        public virtual UserPersonalInfo UserPersonalInfo { get; set; }
        public virtual Contingent Contingent { get; set; }
        public virtual Doctor Doctor { get; set; }

        // virtual collections
        public virtual ICollection<MedicalTestResult> MedicalTestResults { get; set; }
        public virtual ICollection<MedicalTestReferral> MedicalTestReferrals { get; set; }
    }
}
