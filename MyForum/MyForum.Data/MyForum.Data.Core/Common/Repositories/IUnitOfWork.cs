using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Identity;
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
        IRepository<MainCategory> MainCategoryRepository { get; }
        ITopicCategoryRepository TopicCategoryRepository { get; }
        ITopicRepository TopicRepository { get; }
        IPostRepository PostRepository { get; }

        /// <summary>
        /// here we use Identities entities
        /// </summary>
        UserManager UserManager { get; }
        RoleManager RoleManager { get; }

        // TODO Task CommitAsync()
        /// <summary>
        /// Commit all changes
        /// </summary>
        void Commit();
    }
}
