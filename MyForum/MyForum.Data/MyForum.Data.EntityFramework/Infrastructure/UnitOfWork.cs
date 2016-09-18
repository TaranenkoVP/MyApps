using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Identity;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;
using MyForum.Data.EF.Repositories;

namespace MyForum.Data.EF.Infrastructure
{
    /// <summary>
	/// Class <see cref="IUnitOfWork"/> define database unit of work with Entity Framework context
	/// </summary>
	/// 
    public class UnitOfWork : IUnitOfWork
    {
        // TODO Implement Factory
        #region Fields

        private readonly MyForumDbContext _context;
        private bool _disposed;

        private IDeletableEntityRepository<Post> _postRepository;
        private IDeletableEntityRepository<TopicCategory> _topicCategoryRepository;
        private IDeletableEntityRepository<Topic> _topicRepository;

        private UserManager userManager;
        private RoleManager roleManager;

        #endregion

        #region Properties

        public IDeletableEntityRepository<Post> PostRepository
        {
            get
            {
                return _postRepository ?? (_postRepository = new DeletableEntityRepository<Post>(_context));
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
            get
            {
                return _topicRepository ?? (_topicRepository = new DeletableEntityRepository<Topic>(_context));
            }
        }

        public UserManager UserManager => userManager;

        public RoleManager RoleManager => roleManager;

        #endregion

        #region .ctor

        /// <summary>
        /// The class constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            _context = new MyForumDbContext(connectionString);

            userManager = new UserManager(new UserStore<ApplicationUser>(_context));
            roleManager = new RoleManager(new RoleStore<ApplicationRole>(_context));
        }
        
        #endregion

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
