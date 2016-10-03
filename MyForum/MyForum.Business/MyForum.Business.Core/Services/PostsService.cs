using System;
using System.Linq;
using System.Linq.Expressions;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class PostsService : BaseService, IPostsService
    {
        public PostsService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public PostBusiness GetById(int id)
        {
            return Mapper.Map<PostBusiness>(Database.PostRepository.GetById(id));
        }

        public int GetPostsCount(Expression<Func<Post, bool>> rule)
        {
            var postCount = Database.PostRepository.GetCount(rule);

            return postCount;
        }

        public PostBusiness GetLatestPost(Expression<Func<Post, bool>> filter = null,
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null,
            string includeProperties = "")
        {
            var posts = Database.PostRepository.Get(filter, orderBy, includeProperties, 1);

            // if (posts.ToList())

            if (posts != null)
            {
                return Mapper.Map<PostBusiness>(posts.FirstOrDefault());
            }
            return null;
        }

        public virtual void Add(PostBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.PostRepository.Add(Mapper.Map<Post>(entity));
            Database.Commit();
        }

        public virtual void Update(PostBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            var post = Database.PostRepository.GetById(entity.Id);
            post = Mapper.Map(entity, post);

            Database.PostRepository.Update(post);
            Database.Commit();
        }

        public virtual void Delete(PostBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.PostRepository.Delete(Mapper.Map<Post>(entity));
            Database.Commit();
        }
    }
}