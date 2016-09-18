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
    public class TopicsService : BaseService<Topic, TopicBusiness>, ITopicsService
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

            Topic y = Database.TopicRepository.GetFirstOrDefault(
                filter: d => d.Category.Id == id,
                orderBy: q => q.OrderByDescending(d => d.CreatedOn),
                includeProperties: "Category");

            var od = y.GetType();

            var topic = Mapper.Map<TopicBusiness>(y
                            );

            if (topic == null)
            {
                throw new ValidationException("Topic not found");
            }

            return topic;
        }

        //public void Add(TopicBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic is unspecified");
        //    }

        //    Database.TopicRepository.Add(Mapper.Map<Topic>(entity));

        //    Database.Commit();
        //}

        //public void Update(TopicBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic is Null");
        //    }

        //    Database.TopicRepository.Update(Mapper.Map<Topic>(entity));
        //    Database.Commit();
        //}

        //public void Delete(TopicBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic is Null");
        //    }

        //    Database.TopicRepository.Delete(Mapper.Map<Topic>(entity));
        //    Database.Commit();
        //}

    }
}

