using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _database;

        public TopicService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public IQueryable<TopicBusiness> GetAllTopics()
        {
            var topics = new TopicMapper().GetWrapped(_database.TopicRepository.GetAll());

            if (topics == null)
            {
                throw new ValidationException("Topics not found");
            }

            return topics.AsQueryable();
        }

        public TopicBusiness GetTopic(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Topic id is null");
            }

            var topic = new TopicMapper().GetWrapped(_database.TopicRepository.GetById(id.Value));

            if (topic == null)
            {
                throw new ValidationException("Topic not found");
            }

            return topic;
        }

        public void Add(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic is unspecified");
            }

            _database.TopicRepository.Add(new TopicMapper().GetWrapped(entity));

            _database.Commit();
        }

        public void Update(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic is Null");
            }

            _database.TopicRepository.Update(new TopicMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Delete(TopicBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic is Null");
            }

            _database.TopicRepository.Delete(new TopicMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}

