using System.Collections.Generic;
using System.Linq;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class TopicCategoriesService : BaseService, ITopicCategoriesService
    {
        /// <summary>
        ///     Posts service
        /// </summary>
        private readonly IPostsService _postsService;

        /// <summary>
        ///     Topics service
        /// </summary>
        private readonly ITopicsService _topicsService;

        public TopicCategoriesService(IUnitOfWork uow, ITopicsService topicsService, IPostsService postsService)
            : base(uow)
        {
            _topicsService = topicsService;
            _postsService = postsService;
        }

        public IEnumerable<TopicCategoryBusiness> GetAllWithTopics()
        {
            var topicCategories = Mapper.Map<List<TopicCategoryBusiness>>(
                Database.TopicCategoryRepository.Get(includeProperties: "MainCategory, Topics"));

            foreach (var topicCategory in topicCategories)
            {
                GetTopicsStatistic(topicCategory.Topics);
            }

            return topicCategories;
        }

        public TopicCategoryBusiness GetByIdWithTopics(int id)
        {
            var topicCategory = Database.TopicCategoryRepository.Get(x => x.Id == id,
                includeProperties: "MainCategory, Topics")
                .FirstOrDefault();

            var topicCategoryBusiness = Mapper.Map<TopicCategoryBusiness>(topicCategory);

            GetTopicsStatistic(topicCategoryBusiness.Topics);

            return topicCategoryBusiness;
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

        public virtual void Add(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicCategoryRepository.Add(Mapper.Map<TopicCategory>(entity));
            Database.Commit();
        }

        public virtual void Update(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicCategoryRepository.Update(Mapper.Map<TopicCategory>(entity));
            Database.Commit();
        }

        public virtual void Delete(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.TopicCategoryRepository.Delete(Mapper.Map<TopicCategory>(entity));
            Database.Commit();
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

        private void GetTopicsStatistic(IEnumerable<TopicBusiness> topics)
        {
            foreach (var topic in topics)
            {
                topic.PostsCount = _postsService.GetPostsCount(
                    d => d.Topic.Id == topic.Id);

                topic.LatestPost =
                    _postsService.GetLatestPost(d => d.Topic.Id == topic.Id, q => q.OrderByDescending(d => d.CreatedOn),
                        "Author");
            }
        }
    }
}