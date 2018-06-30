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
                mngr.ApplyMigration(new SeedRolesMigration("E26AB260-8248-4885-B6A7-F421CF1C2B88"));
                mngr.ApplyMigration(new SeedDiseasesAndSympthomesMigration("FF2BFDA1-C5E2-4D7C-BB6E-9A40F568984C"));
                mngr.ApplyMigration(new SeedTestProfilesMigration("C3C931BC-41C2-42BB-8BB1-A7B404F16C48"));
                mngr.ApplyMigration(new SeedContingents("A4C0BEBF-52D8-4597-8217-2F85776EA733"));
                mngr.ApplyMigration(new SeedDoctorAndPatient("D767F493-789F-4243-B702-D462B98647FE"));
                //mngr.ApplyMigration(new (""));
            }
            context.Dispose();
        }
    }
}