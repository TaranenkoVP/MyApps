using MyForum.Data.Core.Common;
using MyForum.Data.EF.Infrastructure;
using Ninject.Modules;

namespace MyForum.Business.Core.Infrastructure
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
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}