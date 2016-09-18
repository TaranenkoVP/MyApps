using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using Ninject;

namespace MyForum.Business.Core.Services
{
    
    public class TopicCategoriesService : DeletableBaseService<TopicCategory, TopicCategoryBusiness>, ITopicCategoriesService
    {
        public TopicCategoriesService(IUnitOfWork uow)
           : base(uow , uow.TopicCategoryRepository)
        {

        }

        public TopicCategoryBusiness GetTopicCategory(int id)
        {

            var topicCategory = Mapper.Map<TopicCategoryBusiness>(Database.TopicCategoryRepository.GetById(id));

            if (topicCategory == null)
            {
                throw new ValidationException("Topic Category not found");
            }

            return topicCategory;
        }

        public IEnumerable<TopicCategoryBusiness> GetAll()
        {
            var topicCategories = Mapper.Map<List<TopicCategoryBusiness>>(Database.TopicCategoryRepository.GetAll());

            if (topicCategories == null)
            {
                throw new ValidationException("Topics not found");
            }

            return topicCategories;
        }

        //public void Add(TopicCategoryBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic Category is unspecified");
        //    }

        //    Database.TopicCategoryRepository.Add(Mapper.Map<TopicCategory>(entity));
        //    Database.Commit();
        //}

        //public void Update(TopicCategoryBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic Category is unspecified");
        //    }

        //    Database.TopicCategoryRepository.Update(Mapper.Map<TopicCategory>(entity));
        //    Database.Commit();
        //}

        //public void Delete(TopicCategoryBusiness entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ValidationException("Topic Category is unspecified");
        //    }

        //    Database.TopicCategoryRepository.Delete(Mapper.Map<TopicCategory>(entity));
        //    Database.Commit();
        //}

    }
}
