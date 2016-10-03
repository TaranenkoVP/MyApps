using System;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Identity;
using MyForum.Data.Core.Models;

namespace MyForum.Data.Core.Common
{
    /// <summary>
    ///     Class <see cref="IUnitOfWork" /> that handles multiple Repositories
    ///     This is not specific to which Data Access
    ///     tools your are using (Direct SQL, EF, NHibernate, etc)
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IDeletableEntityRepository<MainCategory> MainCategoryRepository { get; }
        IDeletableEntityRepository<TopicCategory> TopicCategoryRepository { get; }
        IDeletableEntityRepository<Topic> TopicRepository { get; }
        IDeletableEntityRepository<Post> PostRepository { get; }

        /// <summary>
        ///     here we use Identity entities
        /// </summary>
        UserManager UserManager { get; }
        RoleManager RoleManager { get; }

        /// <summary>
        ///     Commit all changes
        /// </summary>
        Task CommitAsync();
    }
}