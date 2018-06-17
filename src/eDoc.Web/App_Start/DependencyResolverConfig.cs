using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.App_Start
{
    public static class DependencyResolverConfig
    {
        public static void Configure(IDependencyResolver resolver)
        {
            DependencyResolver.SetResolver(resolver);
        }
    }
}