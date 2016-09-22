using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class MainCategoriesService : BaseService<MainCategory, MainCategoryBusiness>, IMainCategoriesService
    {
        /// <summary>
        /// Topics service
        /// </summary>
        private readonly ITopicsService _topicsService;

        /// <summary>
        /// Posts service
        /// </summary>
        private readonly IPostsService _postsService;

        public MainCategoriesService(IUnitOfWork uow, ITopicsService topicsService, IPostsService postsService)
            : base(uow, uow.MainCategoryRepository)
        {
            _topicsService = topicsService;
            _postsService = postsService;
        }

        public IEnumerable<MainCategoryBusiness> GetAll()
        {
            var mainCategories = Mapper.Map<List<MainCategoryBusiness>>(
                Database.MainCategoryRepository.Get(
                    includeProperties: "TopicCategories").ToList());//, TopicCategories.Topics, TopicCategories.Topics.Posts

            foreach (var category in mainCategories)
            {
                foreach (var topicCategory in category.TopicCategories)
                {
                    topicCategory.TopicsCount = _topicsService.GetTopicsCountByCategoryId(topicCategory.Id);
                    topicCategory.PostsCount = _topicsService.GetPostsCountByCategoryId(topicCategory.Id);
                    topicCategory.LatestPost = _topicsService.GetLatestPostByCategoryId(topicCategory.Id);
                }
            }

            return mainCategories;
        }
    }
}
