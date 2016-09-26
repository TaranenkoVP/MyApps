using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using MyForum.Business.Core.Infrastructure.Mappers;

namespace MyForum.Business.Core.Services.Common
{
    public abstract class BaseService 
    {
        protected IUnitOfWork Database;
        private static IMapper _mapper;

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
