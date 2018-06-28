﻿using eDoc.Model.Common.Constants;
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
        public async Task<ApplicationUserBase> CreateDoctor(string email, string password)
        {
            var wrapper = await CreateUserAccount(email, password);
            var doctor = new Doctor()
            {
                UserPersonalInfoId = wrapper.Info.Id,
                Bio = "Your bio here..."
            };
            var dbUser = _uow.Users.Get(wrapper.Info.Id);
            dbUser.AvatarPath = DataConstants.Defaults.DocAvatarPath;
            dbUser.AvatarThumbnailPath = DataConstants.Defaults.DocAvatarThumbnailPath;
            _uow.Users.Update(dbUser);
            _uow.Doctors.Add(doctor);
            await _uow.SaveChangesAsync();
            return wrapper.Account;
        }

        public async Task<ApplicationUserBase> CreatePatient(string email, string password)
        {
            var wrapper = await CreateUserAccount(email, password);
            var patient = new Patient()
            {
                UserPersonalInfoId = wrapper.Info.Id,
                LastVisit = null
            };
            var dbUser = _uow.Users.Get(wrapper.Info.Id);
            dbUser.AvatarPath = DataConstants.Defaults.PatientAvatarPath;
            dbUser.AvatarThumbnailPath = DataConstants.Defaults.PatientAvatarThumbnailPath;
            _uow.Users.Update(dbUser);
            _uow.Patients.Add(patient);
            await _uow.SaveChangesAsync();
            return wrapper.Account;
        }

        private async Task<(ApplicationUserBase Account, UserPersonalInfo Info)> CreateUserAccount(string email, string password)
        {
            var user = new ApplicationUserBase()
            {
                UserName = email,
                Email = email,
                CreationDate = _utcExectionTime,
                LastModifiedDate = _utcExectionTime,
                LastVisitedDate = _utcExectionTime
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
                return (Account: user, Info: newUserInfo);
            }
            throw new Exception("Unexpected exception");
        }
    }
}
