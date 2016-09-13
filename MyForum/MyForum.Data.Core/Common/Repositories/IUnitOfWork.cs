using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Models;

namespace MyForum.Data.Core.Common.Repositories
{
    /// <summary>
    /// Class <see cref="IUnitOfWork"/> that handles multiple Repositories
    /// This is not specific to which Data Access
    /// tools your are using (Direct SQL, EF, NHibernate, etc)
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IDeletableEntityRepository<Post> PostRepository { get; }
        IDeletableEntityRepository<TopicCategory> TopicCategoryRepository { get; }
        IDeletableEntityRepository<Topic> TopicRepository { get; }

        /// <summary>
        /// Commit all changes
        /// </summary>
        void Commit();
    }
}
