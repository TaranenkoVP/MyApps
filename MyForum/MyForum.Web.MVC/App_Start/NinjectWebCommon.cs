//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyForum.Web.MVC.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyForum.Web.MVC.App_Start.NinjectWebCommon), "Stop")]

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;

namespace MyForum.Web.MVC.App_Start
{
    public class NinjectWebCommon
    {
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
               // kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
               //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(b => b
                .From("MyForum.Business.Core")
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
