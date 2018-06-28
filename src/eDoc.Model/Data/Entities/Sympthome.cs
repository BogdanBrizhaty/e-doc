using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    // importable
    public class Sympthome : DbEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DiseaseSympthomeMapping> SympthomeMappings { get; set; }
        public virtual ICollection<DiseaseComplaint> DiseaseComplaints { get; set; }
    }
}
