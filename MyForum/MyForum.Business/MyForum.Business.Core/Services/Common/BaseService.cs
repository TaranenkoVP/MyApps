using System.Reflection;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common;

namespace MyForum.Business.Core.Services.Common
{
    public abstract class BaseService
    {
        private static IMapper _mapper;
        protected IUnitOfWork Database;

        protected BaseService(IUnitOfWork uow)
        {
            Database = uow;
        }

        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var autoMapperConfig = new AutoMapperConfig();
                    autoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly().GetName().Name);
                }

                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public virtual void Dispose()
        {
            Database.Dispose();
        }
    }
}