using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class ApplicationUserBase : IdentityUser, IDbEntity<string>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserBase, string> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime LastVisitedDate { get; set; }

        public string AvatarPath { get; set; }
        public string AvatarThumbnailPath { get; set; }

        public virtual UserPersonalInfo PersonalInfo { get; set; }
    }
}
