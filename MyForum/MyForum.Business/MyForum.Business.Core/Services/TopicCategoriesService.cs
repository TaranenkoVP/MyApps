using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class TopicCategoriesService : EntityService, ITopicCategoriesService
    {
        /// <summary>
        ///     Posts service
        /// </summary>
        private readonly IPostsService _postsService;

        public TopicCategoriesService(IUnitOfWork uow, IPostsService postsService)
            : base(uow)
        {
            _postsService = postsService;
        }

        public async Task<IEnumerable<TopicCategoryBusiness>> GetAllWithTopicsAsync()
        {
            var topicCategories = await Task.Run(() => Database.TopicCategoryRepository.Get(
                includeProperties: "MainCategory, Topics"));
            var topicCategoriesBusiness = Mapper.Map<List<TopicCategoryBusiness>>(topicCategories);
            foreach (var topicCategory in topicCategoriesBusiness)
            {
                GetTopicsStatistic(topicCategory.Topics);
            }
            return topicCategoriesBusiness;
        }

        public async Task<TopicCategoryBusiness> GetByIdAsync(int id)
        {
            var topicCategory = await Task.Run(() => Database.TopicCategoryRepository.Get()
                .FirstOrDefault(x => x.Id == id));
            var topicCategoryBusiness = Mapper.Map<TopicCategoryBusiness>(topicCategory);
            return topicCategoryBusiness;
        }

        public async Task<TopicCategoryBusiness> GetByIdWithTopicsAsync(int id)
        {
            var topicCategory = await Task.Run(() =>
                Database.TopicCategoryRepository.Get(x => x.Id == id,
                    includeProperties: "MainCategory, Topics")
                    .FirstOrDefault());
            var topicCategoryBusiness = Mapper.Map<TopicCategoryBusiness>(topicCategory);
            GetTopicsStatistic(topicCategoryBusiness.Topics);
            return topicCategoryBusiness;
        }

        public async Task<IEnumerable<TopicCategoryBusiness>> GetAllAsync()
        {
            var topicCategories = await Task.Run(() => Database.TopicCategoryRepository.GetAll());
            return Mapper.Map<List<TopicCategoryBusiness>>(topicCategories);
        }

        public async Task<TopicCategoryBusiness> AddAsync(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.TopicCategoryRepository.Add(Mapper.Map<TopicCategory>(entity));
            await Database.CommitAsync();
            return entity;
        }

        public async Task<TopicCategoryBusiness> EditAsync(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            var topicCategory = Database.TopicCategoryRepository.GetById(entity.Id);
            if (topicCategory == null)
            {
                return null;
            }
            Mapper.Map(entity, topicCategory);
            Database.TopicCategoryRepository.Update(topicCategory);
            await Database.CommitAsync();
            return entity;
        }

        public async Task<TopicCategoryBusiness> DeleteAsync(TopicCategoryBusiness entity)
        {
            if (entity == null)
            {
                return null;
            }
            Database.TopicCategoryRepository.Delete(Mapper.Map<TopicCategory>(entity));
            await Database.CommitAsync();
            return entity;
        }
        // TODO async
        private void GetTopicsStatistic(IEnumerable<TopicBusiness> topics)
        {
            foreach (var topic in topics)
            {
                topic.PostsCount = _postsService.GetPostsCount(
                    d => d.Topic.Id == topic.Id);
                topic.LatestPost = _postsService.GetLatestPost(
                    d => d.Topic.Id == topic.Id, q => q.OrderByDescending(d => d.CreatedOn), "ApplicationUser");
            }
        }
    }
}