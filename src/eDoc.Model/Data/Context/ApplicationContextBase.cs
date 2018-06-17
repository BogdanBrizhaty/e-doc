using eDoc.Model.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public abstract class ApplicationContextBase : IdentityDbContext<ApplicationUserBase>
    {
        public ApplicationContextBase()
            : this("DefaultConnection")
        {
        }

        public ApplicationContextBase(string connStringName)
            :base(connStringName, throwIfV1Schema: false)
        {

        }

        public static TContextType Create<TContextType>() where TContextType : class
        {
            return Activator.CreateInstance(typeof(TContextType)) as TContextType;
        }
    }
}