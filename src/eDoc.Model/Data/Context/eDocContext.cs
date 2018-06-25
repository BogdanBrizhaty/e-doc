using eDoc.Model.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public class EDocContext : ApplicationContextBase
    {
        public DbSet<Migration> ThirdPartyMigrationHistory { get; set; }
        public DbSet<UserPersonalInfo> UserPersonalInfoes { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Sympthome> Sympthomes { get; set; }
        public DbSet<DiseaseSympthomeMapping> DiseaseSympthomeMappings { get; set; }
        public EDocContext(string connStringName) : base(connStringName)
        {
        }
    }
}
