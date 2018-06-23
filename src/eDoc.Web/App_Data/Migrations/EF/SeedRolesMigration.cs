using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Web.Base;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public enum Roles
    {
        Patient,
        Doctor,
        // can be more
    }
    public class SeedRolesMigration : MigrationBase
    {
        public SeedRolesMigration(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            contextBase.Roles.Add(new AppRole() { Name = Roles.Doctor.ToString(), Role = (int)Roles.Doctor });
            contextBase.Roles.Add(new AppRole() { Name = Roles.Patient.ToString(), Role = (int)Roles.Patient });
        }
    }
}