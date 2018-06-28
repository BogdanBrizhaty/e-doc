using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class DiseaseComplaint : DbEntityBase
    {
        // self properties
        public DateTime? Started { get; set; }
        public string Description { get; set; }

        // foreign keys
        [ForeignKey("MedicalRecord")]
        public string MedicalRecordId { get; set; }
        [ForeignKey("Sympthome")]
        public string SympthomeId { get; set; }

        // navigation properties
        public virtual CommonMedicalRecord MedicalRecord { get; set; }
        public virtual Sympthome Sympthome { get; set; }
    }
}
