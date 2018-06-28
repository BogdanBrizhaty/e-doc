using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class UserPersonalInfo : DbEntityBase
    {
        // key / IDbEntity implementation
        [Key]
        [ForeignKey("AppUser")]
        public override string Id { get; set; }

        // custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }

        public string RegistrationAddress { get; set; }
        public string CurrentAddress { get; set; }

        public string CellPhone { get; set; }
        public string ContactEmail { get; set; }

        public bool AllowToCall { get; set; } = false;
        public bool AllowToSMS { get; set; } = true;
        public bool AllowEmailingMe { get; set; } = true;


        // link to Application user main entry
        public virtual ApplicationUserBase AppUser { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
