using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Common.Repositories;

namespace MyForum.Business.Core.Services.Common
{
    public abstract class EntityService : IEntityService
    {
        private static IMapper _mapper;
        protected IUnitOfWork Database;

        protected EntityService(IUnitOfWork uow)
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