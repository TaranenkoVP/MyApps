using System;
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
    public class TopicsService : EntityService, ITopicsService
    {
        public TopicsService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<TopicBusiness> GetByIdWithPostsAsync(int id)
        {
            if (id == 0)
            {
                throw new ValidationException("Invalid id");
            }
            try
            {
                var topic = await Task.Run(() => Database.TopicRepository.Get(
                    includeProperties: "Posts, Posts.ApplicationUser")
                    .FirstOrDefault(x => x.Id == id));
                return Mapper.Map<TopicBusiness>(topic);
            }
            catch (Exception ex)
            {
                throw new CustomDataException("Cant't get topic", ex);
            }
        }

        public int GetTopicsCount(Expression<Func<Topic, bool>> rule = null)
        {
            try
            {
                return Database.TopicRepository.GetCount(rule);
            }
            catch (Exception ex)
            {
                throw new CustomDataException("Cant't get topics count", ex);
            }
        }

        public async Task<OperationDetails> AddAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Topic does not exist", "");
            }
            try
            {
                Database.TopicRepository.Add(Mapper.Map<Topic>(entity));
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }

        public async Task<OperationDetails> EditAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Topic does not exist", "");
            }
            try
            {
                var topic = Database.TopicRepository.Get(x => x.Id == entity.Id).FirstOrDefault();
                if (topic == null)
                {
                    return new OperationDetails(false, "Topic does not exist", "");
                }
                Mapper.Map(entity, topic);
                Database.TopicRepository.Update(topic);
                await Database.CommitAsync();
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "Success", "");
        }

        public async Task<OperationDetails> DeleteAsync(TopicBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Topic does not exist", "");
            }
            try
            {
                Database.TopicRepository.Delete(Mapper.Map<Topic>(entity));
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