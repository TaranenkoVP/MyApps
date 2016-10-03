using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
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
        Task<PostBusiness> AddAsync(PostBusiness postBusiness);
        Task<PostBusiness> EditAsync(PostBusiness postBusiness);
        Task<PostBusiness> DeleteAsync(PostBusiness postBusiness);
    }
}