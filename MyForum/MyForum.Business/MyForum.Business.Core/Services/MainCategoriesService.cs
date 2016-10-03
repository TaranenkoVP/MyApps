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
    public class MainCategoriesService : BaseService, IMainCategoriesService
    {
        /// <summary>
        ///     Posts service
        /// </summary>
        private readonly IPostsService _postsService;

        /// <summary>
        ///     Topics service
        /// </summary>
        private readonly ITopicsService _topicsService;

        public MainCategoriesService(IUnitOfWork uow, ITopicsService topicsService, IPostsService postsService)
            : base(uow)
        {
            _topicsService = topicsService;
            _postsService = postsService;
        }

        public IEnumerable<MainCategoryBusiness> GetAll()
        {
            var mainCategories = Mapper.Map<List<MainCategoryBusiness>>(
                Database.MainCategoryRepository.GetAll());

            return mainCategories;
        }

        public IEnumerable<MainCategoryBusiness> GetAllWithTopicCategories()
        {
            var mainCategories = Mapper.Map<List<MainCategoryBusiness>>(
                Database.MainCategoryRepository.Get(includeProperties: "TopicCategories"));

            foreach (var mainCategory in mainCategories)
            {
                GetTopicCategoriesStatistic(mainCategory.TopicCategories);
            }

            return mainCategories;
        }

        public MainCategoryBusiness GetById(int id)
        {
            var mainCategory = Mapper.Map<MainCategoryBusiness>(
                Database.MainCategoryRepository.Get()
                    .FirstOrDefault(x => x.Id == id));

            return mainCategory;
        }

        public MainCategoryBusiness GetByIdWithTopicCategories(int id)
        {
            var mainCategory = Mapper.Map<MainCategoryBusiness>(
                Database.MainCategoryRepository.Get(
                    includeProperties: "TopicCategories")
                    .FirstOrDefault(x => x.Id == id));

            GetTopicCategoriesStatistic(mainCategory.TopicCategories);

            return mainCategory;
        }

        public virtual void Add(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.MainCategoryRepository.Add(Mapper.Map<MainCategory>(entity));
            Database.Commit();
        }

        public virtual void Update(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }
            var mainCategory = Database.MainCategoryRepository.GetById(entity.Id);
            Mapper.Map(entity, mainCategory);

            Database.MainCategoryRepository.Update(mainCategory);
            Database.Commit();
        }

        public virtual void Delete(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Unspecified entity");
            }

            Database.MainCategoryRepository.Delete(Mapper.Map<MainCategory>(entity));
            Database.Commit();
        }

        private void GetTopicCategoriesStatistic(IEnumerable<TopicCategoryBusiness> topicCategories)
        {
            foreach (var topicCategory in topicCategories)
            {
                topicCategory.PostsCount = _postsService.GetPostsCount(
                    d => d.Topic.TopicCategory.Id == topicCategory.Id);

                topicCategory.TopicsCount = _topicsService.GetTopicsCount(
                    d => d.TopicCategory.Id == topicCategory.Id);

                topicCategory.LatestPost =
                    _postsService.GetLatestPost(d => d.Topic.TopicCategory.Id == topicCategory.Id,
                        q => q.OrderByDescending(d => d.CreatedOn), "Author");
            }
        }
    }
}