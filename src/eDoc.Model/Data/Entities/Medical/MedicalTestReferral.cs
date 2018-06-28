using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class MedicalTestReferral : DbEntityBase
    {
        // self members
        public DateTime? ExecutionDate { get; set; }
        public string ReasonDescription { get; set; }

        // foreign keys
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        [ForeignKey("MedicalTest")]
        public string MedicalTestId { get; set; }
        [ForeignKey("MedicalTestReferral")]
        public string MedicalTestReferralId { get; set; }

        // Navigation properties
        public virtual MedicalTest MedicalTest { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual MedicalTestResult MedicalTestResult { get; set; }

        // collection references
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
