using eDoc.Model.Data.Context;
using eDoc.Model.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public DbUnitOfWork(IDbContextFactory<ApplicationContextBase> contextFactory)
            :this(contextFactory.Create())
        {
        }
        public DbUnitOfWork(ApplicationContextBase applicationContextBase)
        {
            Context = applicationContextBase;
            InitializeRepositories();
        }

        #endregion

        #region UoW Base implementetion

        public void SaveChanges() => Context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
        #endregion

        #region Repositories

        public PersonalUserInfoRepository UserPersonalInfo { get; set; }
        public AppUserRepository Users { get; set; }
        public PatientRepository Patients { get; set; }
        public DoctorRepository Doctors { get; set; }

        #endregion

        private void InitializeRepositories()
        {
            UserPersonalInfo = new PersonalUserInfoRepository(Context);
            Users = new AppUserRepository(Context);
            Patients = new PatientRepository(Context);
            Doctors = new DoctorRepository(Context);
        }
    }
}
