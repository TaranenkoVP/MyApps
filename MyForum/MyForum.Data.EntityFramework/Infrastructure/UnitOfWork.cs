using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
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
        private IDeletableEntityRepository<Answer> _answerRepository;
        private IDeletableEntityRepository<Topic> _topicRepository;

        #endregion

        #region Properties

        public IDeletableEntityRepository<Post> PostRepository
        {
            get
            {
                return _postRepository ?? (_postRepository = new DeletableEntityRepository<Post>(_context));
            }
        }

        public IDeletableEntityRepository<Answer> AnswerRepository
        {
            get
            {
                return _answerRepository ?? (_answerRepository = new DeletableEntityRepository<Answer>(_context));
            }
        }

        public IDeletableEntityRepository<Topic> TopicRepository
        {
            get
            {
                return _topicRepository ?? (_topicRepository = new DeletableEntityRepository<Topic>(_context));
            }
        }

        #endregion

        #region .ctor

        /// <summary>
        /// The class constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(string connectionString)
        {
            _context = new MyForumDbContext(connectionString);
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
