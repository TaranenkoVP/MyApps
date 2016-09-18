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
    public abstract class DeletableBaseService<TEntity, TEntityBusiness> : BaseService<TEntity, TEntityBusiness> where TEntity : class
                                                                where TEntityBusiness : class        //: IBaseService<T>
    {
        private readonly IDeletableEntityRepository<TEntity> _repository;

        protected DeletableBaseService(IUnitOfWork uow, IDeletableEntityRepository<TEntity> repository)
            : base(uow, repository)
        {
            _repository = repository;
        }

        public override void Add(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Add(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public override void Update(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Update(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public override void Delete(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            _repository.Delete(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }


        public override void Dispose()
        {
            Database.Dispose();
        }
    }
}
