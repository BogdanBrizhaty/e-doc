using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUserBase, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUserBase, string> store)
            : base(store)
        {
        }
    }

}
