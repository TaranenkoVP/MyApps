using System;
using System.Linq;
using System.Linq.Expressions;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IPostsService : IDeletable<PostBusiness>
    {
        PostBusiness GetById(int id);
        int GetPostsCount(Expression<Func<Post, bool>> rule);

        PostBusiness GetLatestPost(Expression<Func<Post, bool>> filter = null,
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null,
            string includeProperties = "");
    }
}