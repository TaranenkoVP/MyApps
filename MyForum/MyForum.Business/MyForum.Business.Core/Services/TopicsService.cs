using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class TopicsService : DeletableBaseService<Topic, TopicBusiness>, ITopicsService
    {
        public TopicsService(IUnitOfWork uow)
           : base(uow, uow.TopicRepository)
        {

        }

        public IEnumerable<TopicBusiness> GetAllTopics()
        {
            var topics = Mapper.Map<List<TopicBusiness>>(Database.TopicRepository.GetAll());

            if (topics == null)
            {
                throw new ValidationException("Topics not found");
            }

            return topics;
        }

        public TopicBusiness GetTopic(int id)
        {

            var topic = Mapper.Map<TopicBusiness>(Database.TopicRepository.GetById(id));

            if (topic == null)
            {
                throw new ValidationException("Topic not found");
            }

            return topic;
        }

        public TopicBusiness GetLastCreatedByCategoryId(int id)
        {
            var topic = Mapper.Map<TopicBusiness>(
                            Database.TopicRepository.GetFirstOrDefault(
                                filter: d => d.TopicCategory.Id == id,
                                orderBy: q => q.OrderByDescending(d => d.CreatedOn),
                                includeProperties: "TopicCategory"));
  
            if (topic == null)
            {
                throw new ValidationException("Topic not found");
            }

            return topic;
        }

        public int GetCountByCategoryId(int id)
        {
            return Database.TopicRepository.GetCountByCategoryId(id);
        }

    }
}

