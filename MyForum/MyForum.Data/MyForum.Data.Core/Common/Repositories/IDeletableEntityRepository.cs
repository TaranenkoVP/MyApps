using System.Collections.Generic;

namespace MyForum.Data.Core.Common.Repositories
{
    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Get all deleted entities from db
        /// </summary>
        IEnumerable<TEntity> AllWithDeleted();

        void ActualDelete(TEntity entity);
    }
}