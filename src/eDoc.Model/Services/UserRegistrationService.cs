using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Entities;
using eDoc.Model.Managers;
using eDoc.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Services
{
    public class UserRegistrationService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly DbUnitOfWork _uow;
        private readonly DateTime _utcExectionTime;

        public UserRegistrationService(ApplicationUserManager userManager, DbUnitOfWork uow)
        {
            _userManager = userManager;
            _uow = uow;
            _utcExectionTime = DateTime.UtcNow;
        }
        public async Task CreateDoctor(string email, string password)
        {
            await CreateUserAccount(email, password);
            //var docor = new doctor
        }

        public async Task CreatePatient(string email, string password)
        {
            await CreateUserAccount(email, password);
            //var docor = new patient
        }

        private async Task CreateUserAccount(string email, string password)
        {
            var user = new ApplicationUserBase()
            {
                UserName = email,
                Email = email,
                CreationDate = _utcExectionTime,
                LastModifiedDate = _utcExectionTime,
                LastVisitedDate = _utcExectionTime,
                AvatarPath = @"//Resources//Images/Defaults\default-avatar-doc.jpg", // move to constant or cfg
                AvatarThumbnailPath = @"//Resources//Images/Defaults\default-avatar-doc.jpg",
            };
            if ((await _userManager.CreateAsync(user, password)).Succeeded)
            {
                var newUserInfo = new UserPersonalInfo()
                {
                    Id = user.Id,
                    ContactEmail = email,
                    CreationDate = _utcExectionTime,
                    BirthDate = _utcExectionTime,
                    LastModifiedDate = _utcExectionTime
                };
                _uow.UserPersonalInfo.Add(newUserInfo);
            }
        }
    }
}
