using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Data.Core.Common.Repositories
{
    /// <summary>
    /// Repository for CRUD Operations and methods
    /// to locate entities within your store. This is not specific to which Data Access
    /// tools your are using (Direct SQL, EF, NHibernate, etc).
    /// </summary>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Get all entities from db
        /// </summary> 
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Provide additional filtering and sorting flexibility without requiring
        /// that you create a derived class with additional methods
        /// </summary>
        /// <param name="query">sql query string</param>
        /// <param name="parameters">parameters for sql query </param>
        /// <returns>IQueryable object.</returns>
        IQueryable<TEntity> GetWithRawSql(string query, params object[] parameters);

        /// <summary>
        /// Allow the calling code to specify a filter condition
        /// and a column to order the results by, and a string parameter 
        /// lets the caller provide a comma-delimited list of navigation properties for eager loading
        /// </summary>
        /// <param name="filter">Filter expression for the return Entities</param>
        /// <param name="orderBy">Represents the order of the return Entities</param>
        /// <param name="includeProperties">Include Properties for the navigation properties</param>
        /// <returns>An IQueryable object.</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(int id);
        
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Detach(TEntity entity);
    }
}
