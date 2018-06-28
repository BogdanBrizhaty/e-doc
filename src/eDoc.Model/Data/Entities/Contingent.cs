using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class Contingent : DbEntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
