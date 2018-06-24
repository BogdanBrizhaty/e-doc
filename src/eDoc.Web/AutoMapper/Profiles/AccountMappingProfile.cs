using eDoc.Model.Data.Entities;
using eDoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.AutoMapper.Profiles
{
    public class AccountMappingProfile : MapperProfileBase
    {
        protected override void CreateProfile()
        {
            CreateMap<UserPersonalInfo, UserInfoModel>();
            CreateMap<UserInfoModel, UserPersonalInfo>();
        }
    }
}