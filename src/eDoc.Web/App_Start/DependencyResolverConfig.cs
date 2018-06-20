using eDoc.Web.NInject;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(eDoc.Web.App_Start.DependencyResolverConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(eDoc.Web.App_Start.DependencyResolverConfig), "Stop")]
namespace eDoc.Web.App_Start
{
    public static class DependencyResolverConfig
    {
        private static readonly Bootstrapper _bootstrapper = new Bootstrapper();
        public static IDependencyResolver Configure(IDependencyResolver resolver)
        {
            DependencyResolver.SetResolver(resolver);
            return resolver;
        }

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            var resolver = new NInjectDependencyResolver();
            Configure(resolver);
            _bootstrapper.Initialize(resolver.GetCurrentKernel);
        }

        public static void Stop()
        {
            _bootstrapper.ShutDown();
        }
    }
}