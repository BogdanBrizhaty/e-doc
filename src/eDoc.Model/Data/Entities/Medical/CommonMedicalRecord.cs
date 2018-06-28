using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class CommonMedicalRecord : DbEntityBase
    {
        public string Title { get; set; }
        string Body { get; set; }

        // foreign keys
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        [ForeignKey("Diagnosis")]
        public string DiseaseId { get; set; }

        // navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Disease Diagnosis { get; set; }

        // virtual collections
        public virtual ICollection<MedicalTestReferral> MedicalTestReferrals { get; set; }
        public virtual ICollection<MedicalTestResult> MedicalTestResults{ get; set; }
        public virtual ICollection<DiseaseComplaint> DiseaseComplaints { get; set; }
    }
}
