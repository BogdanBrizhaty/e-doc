﻿using Microsoft.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Owin;

[assembly: OwinStartupAttribute(typeof(eDoc.Web.Startup))]
namespace eDoc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
