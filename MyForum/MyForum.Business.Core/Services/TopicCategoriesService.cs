using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using Ninject;

namespace MyForum.Business.Core.Services
{
    
    public class TopicCategoriesService : ITopicCategoriesService
    {
        //[Inject]
        private readonly IUnitOfWork _database;
       // [Inject]
        public TopicCategoriesService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public TopicCategoryBusiness GetTopicCategory(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Topic Category is unspecified");
            }

            var topicCategory = new TopicCategoryMapper().GetWrapped(_database.TopicCategoryRepository.GetById(id.Value));

            if (topicCategory == null)
            {
                throw new ValidationException("Topic Category not found");
            }

            return topicCategory;
        }

        public IEnumerable<TopicCategoryBusiness> GetAll()
        {
            var topicCategories = new TopicCategoryMapper().GetWrapped(_database.TopicCategoryRepository.GetAll());

            if (topicCategories == null)
            {
                throw new ValidationException("Topics not found");
            }

            return topicCategories;
        }

        public void Add(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic Category is unspecified");
            }

            _database.TopicCategoryRepository.Add(new TopicCategoryMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Update(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic Category is unspecified");
            }

            _database.TopicCategoryRepository.Update(new TopicCategoryMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Delete(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Topic Category is unspecified");
            }

            _database.TopicCategoryRepository.Delete(new TopicCategoryMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
