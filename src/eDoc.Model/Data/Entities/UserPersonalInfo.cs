using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class UserPersonalInfo : DbEntityBase// IDbEntity<string>
    {
        // key / IDbEntity implementation
        [Key]
        [ForeignKey("AppUser")]
        public override string Id { get; set; }

        //public DateTime CreationDate { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        //public bool IsDeleted { get; set; }

        // custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string CellPhone { get; set; }
        public string ContactEmail { get; set; }
        

        public virtual ApplicationUserBase AppUser { get; set; }
    }
}
