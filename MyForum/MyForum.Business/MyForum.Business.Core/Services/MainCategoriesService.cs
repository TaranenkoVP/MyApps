using System;
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
    public class MainCategoriesService : EntityService, IMainCategoriesService
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

        public async Task<IEnumerable<MainCategoryBusiness>> GetAllAsync()
        {
            try
            {
                var mainCategories = await Task.Run(() => Database.MainCategoryRepository.GetAll());
                var mainCategoriesBusiness = Mapper.Map<List<MainCategoryBusiness>>(mainCategories);
                return mainCategoriesBusiness;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<MainCategoryBusiness>> GetAllWithTopicCategoriesAsync()
        {
            try
            {
                var mainCategories = Database.MainCategoryRepository.Get(includeProperties: "TopicCategories");
                await Task.Run(() => Database.MainCategoryRepository.Get(includeProperties: "TopicCategories"));
                var mainCategoriesBusiness = Mapper.Map<List<MainCategoryBusiness>>(mainCategories);
                foreach (var mainCategory in mainCategoriesBusiness)
                {
                    GetTopicCategoriesStatistic(mainCategory.TopicCategories);
                }
                return mainCategoriesBusiness;
            }
            catch
            {
                return null;
            }
        }

        public async Task<MainCategoryBusiness> GetByIdAsync(int id)
        {
            try
            {
                var mainCategory = await Task.Run(() => Database.MainCategoryRepository.Get()
                    .FirstOrDefault(x => x.Id == id));
                var mainCategoryBusiness = Mapper.Map<MainCategoryBusiness>(mainCategory);
                return mainCategoryBusiness;
            }
            catch
            {
                return null;
            }
        }

        public async Task<MainCategoryBusiness> GetByIdWithTopicCategoriesAsync(int id)
        {
            try
            {
                var mainCategory = await Task.Run(() => Database.MainCategoryRepository.Get(
                    includeProperties: "TopicCategories")
                    .FirstOrDefault(x => x.Id == id));
                var mainCategoryBusiness = Mapper.Map<MainCategoryBusiness>(mainCategory);
                GetTopicCategoriesStatistic(mainCategoryBusiness.TopicCategories);
                return mainCategoryBusiness;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OperationDetails> DeleteAsync(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Main category does not exist", "");
            }
            try
            {
                Database.MainCategoryRepository.Delete(Mapper.Map<MainCategory>(entity));
                await Database.CommitAsync();
                return new OperationDetails(true, "Success", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }
        }

        public async Task<OperationDetails> AddAsync(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Main category does not exist", "");
            }
            try
            {
                Database.MainCategoryRepository.Add(Mapper.Map<MainCategory>(entity));
                await Database.CommitAsync();

                return new OperationDetails(true, "Success", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }
        }

        public async Task<OperationDetails> EditAsync(MainCategoryBusiness entity)
        {
            if (entity == null)
            {
                return new OperationDetails(false, "Main category does not exist", "");
            }
            try
            {
                var mainCategory = Database.MainCategoryRepository.GetById(entity.Id);
                if (mainCategory == null)
                {
                    return new OperationDetails(false, "Main category does not exist", "");
                }
                Mapper.Map(entity, mainCategory);
                Database.MainCategoryRepository.Update(mainCategory);
                await Database.CommitAsync();
                return new OperationDetails(true, "Success", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }
        }

        // TODO async
        private void GetTopicCategoriesStatistic(IEnumerable<TopicCategoryBusiness> topicCategories)
        {
            foreach (var topicCategory in topicCategories)
            {
                topicCategory.PostsCount = _postsService.GetPostsCount(
                    d => d.Topic.TopicCategory.Id == topicCategory.Id);
                topicCategory.TopicsCount = _topicsService.GetTopicsCount(
                    d => d.TopicCategory.Id == topicCategory.Id);
                topicCategory.LatestPost = _postsService.GetLatestPost(
                    d => d.Topic.TopicCategory.Id == topicCategory.Id,
                    q => q.OrderByDescending(d => d.CreatedOn), "ApplicationUser");
            }
        }
    }
}