using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Model.Extensions;
using eDoc.Model.Managers;
using eDoc.Web.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public class SeedTestProfilesMigration : MigrationBase
    {
        public SeedTestProfilesMigration(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUserBase, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(contextBase));
            var context = contextBase as EDocContext;

            CreateUser(manager, context, "patient@test.com", "Password1");
            CreateUser(manager, context, "doctor@test.com", "Password2");
        }

        private void CreateUser(ApplicationUserManager manager, EDocContext context, string email, string password)
        {
            var user = new ApplicationUserBase()
            {
                UserName = email,
                Email = email,
                CreationDate = UtcExecutionTime,
                LastModifiedDate = UtcExecutionTime,
                LastVisitedDate = UtcExecutionTime,
                AvatarPath = @"//Resources//Images/Defaults\default-avatar-doc.jpg",
                AvatarThumbnailPath = @"//Resources//Images/Defaults\default-avatar-doc.jpg",
            };

            if (manager.Create(user, password).Succeeded)
            {
                var newUserInfo = new UserPersonalInfo()
                {
                    Id = user.Id,
                    ContactEmail = email,
                    CreationDate = UtcExecutionTime,
                    BirthDate = UtcExecutionTime.WithOffset(DateTimeUnit.Week.ToMinutes(50)),
                    LastModifiedDate = UtcExecutionTime
                };
                context.UserPersonalInfoes.Add(newUserInfo);
            }
        }
    }
}