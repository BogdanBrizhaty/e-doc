using AutoMapper;
using eDoc.Web.App_Start;
using eDoc.Web.Loader;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.NInject.Modules
{
    public class AutoMapperModule : NinjectModule, IInitializable
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(AutoMapperConfig.GetConfig().CreateMapper());
        }
    }
}