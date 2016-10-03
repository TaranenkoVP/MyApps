using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class PostsService : EntityService, IPostsService
    {
        public PostsService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public int GetPostsCount(Expression<Func<Post, bool>> rule)
        {
            return Database.PostRepository.GetCount(rule);
        }

        public PostBusiness GetLatestPost(Expression<Func<Post, bool>> filter = null,
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null,
            string includeProperties = "")
        {
            var posts = Database.PostRepository.Get(filter, orderBy, includeProperties, 1);
            if (posts != null)
            {
                return Mapper.Map<PostBusiness>(posts.FirstOrDefault());
            }
            return null;
        }

        public async Task<PostBusiness> AddAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.PostRepository.Add(Mapper.Map<Post>(entity));
            await Database.CommitAsync();
            return entity;
        }

        public async Task<PostBusiness> EditAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            var Post = Database.PostRepository.GetById(entity.Id);
            if (Post == null)
            {
                return null;
            }
            Mapper.Map(entity, Post);
            Database.PostRepository.Update(Post);
            await Database.CommitAsync();
            return entity;
        }

        public async Task<PostBusiness> DeleteAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.PostRepository.Delete(Mapper.Map<Post>(entity));
            await Database.CommitAsync();
            return entity;
        }

        public async Task<PostBusiness> GetByIdAsync(int id)
        {
            var post = await Task.Run(() => Database.PostRepository.GetById(id));
            return Mapper.Map<PostBusiness>(post);
        }
    }
}