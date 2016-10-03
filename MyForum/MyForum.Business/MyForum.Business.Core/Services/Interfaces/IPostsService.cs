using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IPostsService : IEntityService
    {
        Task<PostBusiness> GetByIdAsync(int id);
        int GetPostsCount(Expression<Func<Post, bool>> rule);
        PostBusiness GetLatestPost(Expression<Func<Post, bool>> filter = null,
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null,
            string includeProperties = "");
        Task<OperationDetails> AddAsync(PostBusiness postBusiness);
        Task<OperationDetails> EditAsync(PostBusiness postBusiness);
        Task<OperationDetails> DeleteAsync(PostBusiness postBusiness);
        Task<OperationDetails> DeleteByIdAsync(int id);
    }
}