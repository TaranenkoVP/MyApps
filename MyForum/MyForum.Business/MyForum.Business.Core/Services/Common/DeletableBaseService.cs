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
    public abstract class DeletableBaseService<TEntity, TEntityBusiness> : BaseService,
                                                                           IDeletableBaseService<TEntity, TEntityBusiness>
                                                                                where TEntity : class
                                                                                where TEntityBusiness : class      
    {
        protected readonly IRepository<TEntity> Repository;

        protected DeletableBaseService(IUnitOfWork uow, IRepository<TEntity> repository)
            : base(uow)
        {
            Repository = repository;
        }

        public virtual void Add(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Repository.Add(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public virtual void Update(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Repository.Update(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }

        public virtual void Delete(TEntityBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Repository.Delete(Mapper.Map<TEntity>(entity));
            Database.Commit();
        }
    }
}
