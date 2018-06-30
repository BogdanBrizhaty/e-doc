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
    public class AppUserRepository : EfRepositoryBase<ApplicationUserBase, string>
    {
        public AppUserRepository(ApplicationContextBase applicationContext) : base(applicationContext)
        {
        }
        public (ApplicationUserBase User, AppRole Role) GetWithRole(string userId)
        {
            var usr = Get(userId);
            var roleid = usr.Roles.FirstOrDefault().RoleId;
            var role = Context.Set<AppRole>().FirstOrDefault(r => r.Id == roleid);
            return (usr, role);
        }
    }
}
