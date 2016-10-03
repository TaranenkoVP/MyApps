using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Common.Repositories;

namespace MyForum.Data.EF.Repositories.Common
{
    /// <summary>
    ///     Interface <see cref="IDeletableEntityRepository{TEntity}" /> for operations with audits repositories
    /// </summary>
    public class DeletableEntityRepository<TEntity> : GenericRepository<TEntity>, IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity, ITKeyEntity<int>, IAuditInfo
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        //public override TEntity GetById(object id)
        //{
        //    return DbSet.FirstOrDefault(x => x.Id == (int)id);
        //}

        //public override IEnumerable<TEntity> GetAll()
        //{
        //    return DbSet.Where(x => !x.IsDeleted).ToList();
        //}

        //public IEnumerable<TEntity> AllWithDeleted()
        //{
        //    return DbSet.ToList();
        //}

        //public override void Delete(TEntity entity)
        //{
        //    entity.IsDeleted = true;
        //    entity.DeletedOn = DateTime.Now;

        //    DbEntityEntry entry = Context.Entry(entity);
        //    entry.State = EntityState.Modified;
        //}

        //public void ActualDelete(TEntity entity)
        //{
        //    base.Delete(entity);
        //}

        //public void ActualDeleteById(int id)
        //{
        //    base.Delete(id);
        //}
    }
}