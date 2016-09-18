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

namespace MyForum.Business.Core.Services
{
    public abstract class BaseService<TEntity, TEntityBusiness> where TEntity : class
                                                                where TEntityBusiness : class        //: IBaseService<T>
    {
        private readonly IDeletableEntityRepository<TEntity> _repository;
        protected IUnitOfWork Database;
        private static IMapper _mapper;


        protected BaseService(IUnitOfWork uow, IDeletableEntityRepository<TEntity> repository)
        {
            Database = uow;
            _repository = repository;
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


        public virtual void Add(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Add(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public virtual void Update(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Update(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public virtual void Delete(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Delete(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }


        public virtual void Dispose()
        {
            Database.Dispose();
        }
    }
}
