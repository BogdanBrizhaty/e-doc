using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.AutoMapper
{
    public abstract class MapperProfileBase : Profile
    {
        public MapperProfileBase()
        {
            CreateProfile();
        }
        protected abstract void CreateProfile();
    }
}