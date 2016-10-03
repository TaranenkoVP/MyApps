using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
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

        public PostBusiness GetLatestPost(Expression<Func<Post, bool>> filter = null,
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                var posts = Database.PostRepository.Get(filter, orderBy, includeProperties, 1);
                return posts != null ? Mapper.Map<PostBusiness>(posts.FirstOrDefault()) : null;
            }
            catch (Exception ex)
            {
                throw new CustomDataException("Cant't get latest post", ex);
            }
        }

        public async Task<PostBusiness> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ValidationException("Invalid id");
            }
            try
            {
                var post = await Task.Run(() => Database.PostRepository.GetById(id));
                return Mapper.Map<PostBusiness>(post);
            }
            catch (Exception ex)
            {
                throw new CustomDataException("Cant't get post", ex);
            }
        }

        public int GetPostsCount(Expression<Func<Post, bool>> rule = null)
        {
            try
            {
                return Database.PostRepository.GetCount(rule);
            }
            catch (Exception ex)
            {
                throw new CustomDataException("Can't count posts", ex);
            }
        }

        public async Task<OperationDetails> AddAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Post does not exist", "");
            }
            try
            {
                Database.PostRepository.Add(Mapper.Map<Post>(entity));
                entity.CreatedOn = DateTime.Now;
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }

        public async Task<OperationDetails> EditAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Post does not exist", "");
            }
            try
            {
                var post = Database.PostRepository.GetById(entity.Id);
                if (post == null)
                {
                    return new OperationDetails(false, "Post does not exist", "");
                }
                Mapper.Map(entity, post);
                Database.PostRepository.Update(post);
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }

        public async Task<OperationDetails> DeleteByIdAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "invalid id", "");
            }
            try
            {
                Database.PostRepository.Delete(id);
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }

        public async Task<OperationDetails> DeleteAsync(PostBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Post does not exist", "");
            }
            try
            {
                Database.PostRepository.Delete(Mapper.Map<Post>(entity));
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }
    }
}