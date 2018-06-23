using eDoc.Model.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.UnitOfWork
{
    public class DbUnitOfWork : IUnitOfWork
    {
        protected ApplicationContextBase Context { get; }

        #region Constructors
        [Obsolete("For moq only")]
        public DbUnitOfWork() { }

        public DbUnitOfWork(ApplicationContextBase applicationContext) => Context = applicationContext;

        #endregion

        #region UoW Base implementetion

        public void SaveChanges() => Context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
        #endregion

        #region Repositories



        #endregion
    }
}
