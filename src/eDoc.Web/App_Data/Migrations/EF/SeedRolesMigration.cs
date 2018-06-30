using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Web.Base;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public class SeedRolesMigration : MigrationBase
    {
        public SeedRolesMigration(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            contextBase.Roles.Add(new AppRole() { Name = RoleAccessPoint.Doctor.ToString(), Role = (int)RoleAccessPoint.Doctor });
            contextBase.Roles.Add(new AppRole() { Name = RoleAccessPoint.Patient.ToString(), Role = (int)RoleAccessPoint.Patient });
            contextBase.Roles.Add(new AppRole() { Name = RoleAccessPoint.SuperUser.ToString(), Role = (int)RoleAccessPoint.SuperUser });
            contextBase.Roles.Add(new AppRole() { Name = RoleAccessPoint.Administrator.ToString(), Role = (int)RoleAccessPoint.Administrator });
            contextBase.Roles.Add(new AppRole() { Name = RoleAccessPoint.SystemProfile.ToString(), Role = (int)RoleAccessPoint.SystemProfile });
        }
    }
}