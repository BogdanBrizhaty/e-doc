using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Model.Data.Entities
{
    public class DiseaseSympthomeMapping : DbEntityBase
    {
        [ForeignKey("Disease")]
        public string DiseaseId { get; set; }

        [ForeignKey("Sympthome")]
        public string SympthomeId { get; set; }


        public virtual Disease Disease { get; set; }
        public virtual Sympthome Sympthome { get; set; }
    }
}