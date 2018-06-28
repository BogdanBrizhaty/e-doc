using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Model.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Repositories
{
    public class PatientRepository : EfRepositoryBase<Patient, string>
    {
        public PatientRepository(ApplicationContextBase applicationContext) : base(applicationContext)
        {
        }
    }
}
