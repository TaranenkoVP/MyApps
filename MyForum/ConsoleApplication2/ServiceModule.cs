using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Services;
using MyForum.Business.Core.Services.Interfaces;
using Ninject.Modules;

namespace ConsoleApplication2
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<ITopicCategoriesService>().To<TopicCategoriesService>().WithConstructorArgument(_connectionString);
        }

    }
}
