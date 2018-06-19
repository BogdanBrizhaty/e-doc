using eDoc.Model.Data.Context;
using eDoc.Model.Services;
using eDoc.Web.Base;
using eDoc.Web.Loader;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.NInject
{
    public class NInjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        #region Constructors
        private NInjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));

            _kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            _kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            _kernel.Bind<IControllerFactory>().To<DefaultControllerFactory>();
            _kernel.Unbind<ModelValidatorProvider>();

            _kernel.Bind<ApplicationContextBase>()
                .To<EDocContext>()
                .WithConstructorArgument("connStringName", App.Settings.ActiveDbConnectionName);

            _kernel.Bind<OwinFactory>()
                .ToSelf()
                .WithConstructorArgument("connStringName", App.Settings.ActiveDbConnectionName);

            LoadModules();
        }

        public IKernel GetCurrentKernel()
        {
            return _kernel;
        }

        public NInjectDependencyResolver()
            : this(new StandardKernel())
        {

        }

        private void LoadModules()
        {
            var modules = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(NinjectModule).IsAssignableFrom(t))
                .ToList();

            modules.ForEach(m => _kernel.Load(TypeLoader.Initialize<INinjectModule>(m)));
        }

        public NInjectDependencyResolver(INinjectModule initialModule)
            : this(new StandardKernel(initialModule))
        {
        }

        public NInjectDependencyResolver(HashSet<INinjectModule> modules)
            : this(new StandardKernel(modules.ToArray()))
        {
        }

        #endregion

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}