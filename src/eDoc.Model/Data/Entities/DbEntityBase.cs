using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public abstract class DbEntityBase : IDbEntity<string>
    {
        [Key]
        public virtual string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        // ctor
        public DbEntityBase() => Id  = Guid.NewGuid().ToString();
    }
}
