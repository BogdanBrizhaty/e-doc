using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Model.Extensions;
using eDoc.Model.Managers;
using eDoc.Model.Services;
using eDoc.Model.UnitOfWork;
using eDoc.Web.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public class SeedDoctorAndPatient : MigrationBase
    {
        public SeedDoctorAndPatient(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUserBase, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(contextBase));
            var uow = new DbUnitOfWork(contextBase);
            var service = new UserRegistrationService(manager, uow);
            // should be sync as Migration is not awaitable and there is conflicting requests
            var profile1 = service.CreatePatient("patient@test.com", "Password1").Result;
            var profile2 = service.CreateDoctor("doctor@test.com", "Password2").Result;
        }
    }
}