using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Data.Common.Repository
{
    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all deleted entities from db
        /// </summary> 
        IQueryable<TEntity> AllWithDeleted();

        void ActualDelete(TEntity entity);
    }
}
