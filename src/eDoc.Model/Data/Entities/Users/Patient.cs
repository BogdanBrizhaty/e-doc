using System;
using System.Collections.Generic;
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

        public DateTime? LastVisit { get; set; }
        public int Gender { get; set; }
        public string WorkPlace { get; set; }
        public string PrivilegeCertificateNo { get; set; }

        public string UserPersonalInfoId { get; set; }
        public string ContingentId { get; set; }
        public virtual UserPersonalInfo UserPersonalInfo { get; set; }
        public virtual Contingent Contingent { get; set; }
        public virtual ICollection<MedicalTestResult> MedicalTestResults { get; set; }
    }
}
