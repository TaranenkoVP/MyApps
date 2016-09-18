using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common.Repositories;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IBaseService<TEntity, in TEntityBusiness> : IDisposable where TEntity : class
                                                                    where TEntityBusiness : class
    {
        void Add(TEntityBusiness entity);
        void Update(TEntityBusiness entity);
        void Delete(TEntityBusiness entity);
    }
}
