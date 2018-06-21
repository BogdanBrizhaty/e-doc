using eDoc.Model.Data.Context;
using eDoc.Model.Data.Migrations;
using eDoc.Web.Base;
using eDoc.Web.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Managers
{
    public sealed class MigrationManager : IDisposable
    {
        public abstract class MigrationBase : IInitializable
        {
            public string Id { get; }
            public MigrationBase(string key)
            {
                Id = key;
            }
            public void Execute(ApplicationContextBase contextBase)
            {
                OnExecute(contextBase);
                contextBase.SaveChanges();
            }
            protected abstract void OnExecute(ApplicationContextBase contextBase);
        }

        private ApplicationContextBase _context { get; }
        public MigrationManager(ApplicationContextBase context)
        {
            _context = context;
        }

        public void ApplyMigration(MigrationBase migration)
        {
            try
            {
                migration.Execute(_context);
            }
            catch (Exception ex)
            {
                App.OnException(ex, this);
            }
        }

        public void ApplyMigrations(HashSet<MigrationBase> migrations)
        {
            migrations.ToList().ForEach(m => ApplyMigration(m));
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}