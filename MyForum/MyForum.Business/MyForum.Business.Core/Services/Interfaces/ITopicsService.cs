using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicsService : IEntityService
    {
        Task<TopicBusiness> GetByIdWithPostsAsync(int id);

        int GetTopicsCount(Expression<Func<Topic, bool>> rule);

        Task<TopicBusiness> AddAsync(TopicBusiness entity);

        Task<TopicBusiness> EditAsync(TopicBusiness entity);

        Task<TopicBusiness> DeleteAsync(TopicBusiness entity);
    }
}