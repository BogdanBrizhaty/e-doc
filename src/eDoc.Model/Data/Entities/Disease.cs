using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class Disease : DbEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ICDCode { get; set; }

        //International Classification of Diseases and Related Health Problems

        public virtual ICollection<DiseaseSympthomeMapping> SympthomeMappings { get; set; }
        public virtual ICollection<CommonMedicalRecord> MedicalRecords { get; set; }
    }
}
