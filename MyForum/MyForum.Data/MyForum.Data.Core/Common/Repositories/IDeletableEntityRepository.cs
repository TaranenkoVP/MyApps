using System.Collections.Generic;

namespace MyForum.Data.Core.Common.Repositories
{
    /// <summary>
    /// Class <see cref="IDeletableEntityRepository"/>
    /// </summary>
    public interface IDeletableEntityRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///      Get all deleted entities from db
        /// </summary>
        IEnumerable<TEntity> AllWithDeleted();

        void ActualDelete(TEntity entity);
    }
}