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

        public override TEntity GetFirstOrDefault(
              Expression<Func<TEntity, bool>> filter = null,
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
              string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            
            query = query.Where(x => !x.IsDeleted);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.FirstOrDefault();
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
