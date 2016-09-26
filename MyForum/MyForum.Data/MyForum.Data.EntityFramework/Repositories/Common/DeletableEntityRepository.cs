using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Common.Repositories;

namespace MyForum.Data.EF.Repositories.Common
{
    public class DeletableEntityRepository<TEntity> : GenericRepository<TEntity>, IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return DbSet.Where(x => !x.IsDeleted).ToList();
        }

        public IEnumerable<TEntity> AllWithDeleted()
        {
            return DbSet.ToList();
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void ActualDelete(TEntity entity)
        {
            base.Delete(entity);
        }
    }
}
