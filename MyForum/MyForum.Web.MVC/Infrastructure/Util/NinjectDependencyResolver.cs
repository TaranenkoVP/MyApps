﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyForum.Business.Core.Services;
using MyForum.Business.Core.Services.Interfaces;
using Ninject;

namespace MyForum.Web.MVC.Infrastructure.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IPostsService>().To<PostsService>();
            kernel.Bind<ITopicsService>().To<TopicsService>();
            kernel.Bind<ITopicCategoriesService>().To<TopicCategoriesService>();
        }
    }
}
