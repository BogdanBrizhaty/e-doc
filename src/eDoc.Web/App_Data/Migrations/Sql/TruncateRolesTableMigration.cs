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
    public class TruncateRolesTableMigration : MigrationBase
    {
        public TruncateRolesTableMigration(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            contextBase.Database.ExecuteSqlCommand("delete from AspNetRoles");
            contextBase.Set<Migration>().Add(new Migration() { Name = "truncate table AspNetRoles", DateExecuted = DateTime.UtcNow });
        }
    }
}