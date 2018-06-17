using eDoc.Web.Loader;
using Ninject;
using Ninject.Modules;
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
        private readonly IKernel _kernel;

        #region Constructors
        private NInjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
            var fctr = new DefaultControllerFactory();
            _kernel.Bind<IControllerFactory>().ToConstant(fctr);
        }

        public NInjectDependencyResolver()
            :this(new StandardKernel())
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