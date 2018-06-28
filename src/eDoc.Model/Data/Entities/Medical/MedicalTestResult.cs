using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public enum ResultStamp
    {
        A = 5,
        B = 4,
        C = 3,
        D = 2,
        E = 1
    }
    public class MedicalTestResult : DbEntityBase
    {
        // self properties
        public DateTime? DatePerformed { get; set; }
        public int ResultStamp { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }

        // foreign keys
        [ForeignKey("MedicalTestReferral")]
        public string MedicalTestReferralId { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }

        // navigation properties
        public virtual MedicalTestReferral MedicalTestReferral { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
