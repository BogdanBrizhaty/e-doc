using eDoc.Model.Data.Entities;
using eDoc.Model.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public abstract class ApplicationContextBase : IdentityDbContext<ApplicationUserBase, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationContextBase(string connStringName)
            :base(connStringName)
        {

        }
    }
}