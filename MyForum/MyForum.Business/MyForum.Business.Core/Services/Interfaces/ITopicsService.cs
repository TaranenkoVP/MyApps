using System;
using System.Linq.Expressions;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicsService : IDeletable<TopicBusiness>
    {
        TopicBusiness GetByIdWithPosts(int id);
        int GetTopicsCount(Expression<Func<Topic, bool>> rule);
    }
}