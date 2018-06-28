using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class MedicalTest : DbEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
