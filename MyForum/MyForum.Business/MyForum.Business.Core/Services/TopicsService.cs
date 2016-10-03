using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class TopicsService : EntityService, ITopicsService
    {
        public TopicsService(IUnitOfWork uow )
            : base(uow)
        {
        }

        public async Task<TopicBusiness> GetByIdWithPostsAsync(int id)
        {
            var topic = await Task.Run(() => Database.TopicRepository.Get(
                includeProperties: "Posts, Posts.ApplicationUser")
                .FirstOrDefault(x => x.Id == id));
            return Mapper.Map<TopicBusiness>(topic);
        }

        public int GetTopicsCount(Expression<Func<Topic, bool>> rule)
        {
            return Database.TopicRepository.GetCount(rule);
        }

        public async Task<TopicBusiness> AddAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.TopicRepository.Add(Mapper.Map<Topic>(entity));
            await Database.CommitAsync();
            return entity;
        }

        public async Task<TopicBusiness> EditAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            var topic = Database.TopicRepository.GetById(entity.Id);
            if (topic == null)
            {
                return null;
            }
            Mapper.Map(entity, topic);
            Database.TopicRepository.Update(topic);
            await Database.CommitAsync();
            return entity;
        }

        public async Task<TopicBusiness> DeleteAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.TopicRepository.Delete(Mapper.Map<Topic>(entity));
            await Database.CommitAsync();
            return entity;
        }
    }
}