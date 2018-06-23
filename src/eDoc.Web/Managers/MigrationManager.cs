using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Web.Base;
using eDoc.Web.Loader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eDoc.Web.Managers
{
    public sealed class MigrationManager : IDisposable
    {
        public abstract class MigrationBase : IInitializable
        {
            public string Id { get; }
            public string Name { get; set; }
            public string Description { get; set; }

            public MigrationBase(string key)
            {
                Id = key;
            }
            public void Execute(ApplicationContextBase contextBase)
            {
                try
                {
                    OnExecute(contextBase);
                    AfterExecute(contextBase);
                }
                catch(Exception ex)
                {
                    App.OnException(ex, this);
                }
            }
            private void AfterExecute(ApplicationContextBase contextBase)
            {
                contextBase.Set<Migration>().Add(new Migration()
                {
                    Id = Id,
                    DateExecuted = DateTime.UtcNow,
                    Name = Name,
                    Description = Description
                });
                contextBase.SaveChanges();
            }
            protected abstract void OnExecute(ApplicationContextBase contextBase);
        }

        public class FileLocatedMigration : MigrationBase
        {
            public string FilePath { get; }
            public FileLocatedMigration(string key, string fPath) : base(key)
            {
                if (String.IsNullOrEmpty(fPath))
                    throw new ArgumentException();

                FilePath = fPath;
            }

            protected override void OnExecute(ApplicationContextBase contextBase)
            {
                // map to server location
                var command = File.ReadAllText(FilePath);
                contextBase.Database.ExecuteSqlCommand(command);
            }
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
                if (!_context.Set<Migration>().Any(m => m.Id == migration.Id))
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