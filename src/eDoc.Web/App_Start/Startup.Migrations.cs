using eDoc.Model.Data.Context;
using eDoc.Web.App_Data.Migrations;
using eDoc.Web.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web
{
    public partial class Startup
    {
        public static void RunMigrations(ApplicationContextBase context)
        {
            using (var mngr = new MigrationManager(context))
            {
                mngr.ApplyMigration(new SeedRolesMigration("bff784d2-4be9-43fb-bca0-1235fe47a700"));
            }
            context.Dispose();
        }
    }
}