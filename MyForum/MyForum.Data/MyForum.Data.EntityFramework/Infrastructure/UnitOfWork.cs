using System;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Identity;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;
using MyForum.Data.EF.Repositories;
using MyForum.Data.EF.Repositories.Common;

namespace MyForum.Data.EF.Infrastructure
{
    /// <summary>
    ///     Class <see cref="IUnitOfWork" /> define database unit of work with Entity Framework context
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region .ctor

        /// <summary>
        ///     The class constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            _context = new MyForumDbContext(connectionString);

            UserManager = new UserManager(new UserStore<ApplicationUser>(_context));
            RoleManager = new RoleManager(new RoleStore<ApplicationRole>(_context));
        }

        #endregion

        // TODO Implement Factory

        #region Fields

        private readonly MyForumDbContext _context;
        private bool _disposed;

        private IDeletableEntityRepository<MainCategory> _mainCategoryRepository;
        private IDeletableEntityRepository<TopicCategory> _topicCategoryRepository;
        private IDeletableEntityRepository<Topic> _topicRepository;
        private IDeletableEntityRepository<Post> _postRepository;

        #endregion

        #region Properties

        public IDeletableEntityRepository<MainCategory> MainCategoryRepository
        {
            get
            {
                return _mainCategoryRepository ??
                       (_mainCategoryRepository = new DeletableEntityRepository<MainCategory>(_context));
            }
        }

        public IDeletableEntityRepository<TopicCategory> TopicCategoryRepository
        {
            get
            {
                return _topicCategoryRepository ?? (_topicCategoryRepository = new DeletableEntityRepository<TopicCategory>(_context));
            }
        }

        public IDeletableEntityRepository<Topic> TopicRepository
        {
            get { return _topicRepository ?? (_topicRepository = new DeletableEntityRepository<Topic>(_context)); }
        }

        public IDeletableEntityRepository<Post> PostRepository
        {
            get { return _postRepository ?? (_postRepository = new DeletableEntityRepository<Post>(_context)); }
        }

        public UserManager UserManager { get; }

        public RoleManager RoleManager { get; }

        #endregion

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}