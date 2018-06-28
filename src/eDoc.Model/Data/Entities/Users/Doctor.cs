using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public enum DoctorSpecialization
    {
        Therapist,
        Surgeon,
        Ophtalmologist,
        Dentist,
        Physiotherapist,
        // any other that matters
    }
    public class Doctor : DbEntityBase
    {
        // self properties
        public string Workplace { get; set; }
        public string Bio { get; set; }
        public int WorkingExp { get; set; }
        public int SpecializationCode { get; set; }

        // foreign keys
        [ForeignKey("UserPersonalInfo")]
        public string UserPersonalInfoId { get; set; }

        // navigation properties
        public virtual UserPersonalInfo UserPersonalInfo { get; set; }

        // virtual collections
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<MedicalTestReferral> MedicalTestReferrals { get; set; }
    }
}
