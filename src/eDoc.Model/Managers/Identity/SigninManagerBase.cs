using eDoc.Model.Data.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Managers
{
    public class SignInManagerBase : SignInManager<ApplicationUserBase, string>
    {
        public SignInManagerBase(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUserBase user)
        {
            return user.GenerateUserIdentityAsync(UserManager);
        }
    }
}
