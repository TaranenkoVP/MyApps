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
    public class TopicsService : BaseService, ITopicsService
    {
        public TopicsService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public TopicBusiness GetByIdWithPosts(int id)
        {
            var topic = Mapper.Map<TopicBusiness>(
                Database.TopicRepository.Get(
                    includeProperties: "TopicCategory, Posts, Posts.Author")
                    .FirstOrDefault(x => x.Id == id));

            return topic;
        }

        public int GetTopicsCount(Expression<Func<Topic, bool>> rule)
        {
            var topicsCount = Database.TopicRepository.GetCount(rule);

            return topicsCount;
        }

        public virtual void Add(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicRepository.Add(Mapper.Map<Topic>(entity));
            Database.Commit();
        }

        public virtual void Update(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicRepository.Update(Mapper.Map<Topic>(entity));
            Database.Commit();
        }

        public virtual void Delete(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicRepository.Delete(Mapper.Map<Topic>(entity));
            Database.Commit();
        }
    }
}