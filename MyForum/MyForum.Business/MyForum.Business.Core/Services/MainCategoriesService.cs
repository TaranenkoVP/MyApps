using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class MainCategoriesService : DeletableBaseService<MainCategory, MainCategoryBusiness>, IMainCategoriesService
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
                    includeProperties: "TopicCategories, TopicCategories.Topics, TopicCategories.Topics.Posts, TopicCategories.Topics.Posts.Author"));//, 

            //foreach (var mainCategory in mainCategories)
            //{
            //    GetTopicCategoriesStatistic(mainCategory.TopicCategories);
            //}

            return mainCategories;
        }

        public MainCategoryBusiness GetById(int id)
        {
            var mainCategory = Mapper.Map<MainCategoryBusiness>(
                Database.MainCategoryRepository.Get(
                    includeProperties: "TopicCategories, TopicCategories.Topics, TopicCategories.Topics.Posts, TopicCategories.Topics.Posts.Author")
                        .FirstOrDefault(x => x.Id == id));

           // GetTopicCategoriesStatistic(mainCategory.TopicCategories);

            return mainCategory;
        }

        //private void GetTopicCategoriesStatistic(IEnumerable<TopicCategoryBusiness> topicCategories)
        //{
        //    foreach (var topicCategory in topicCategories)
        //    {
        //        topicCategory.TopicsCount = _topicsService.GetTopicsCountByCategoryId(topicCategory.Id);
        //        topicCategory.PostsCount = _topicsService.GetPostsCountByCategoryId(topicCategory.Id);
        //        topicCategory.LatestPost = _topicsService.GetLatestPostByCategoryId(topicCategory.Id);
        //    }
        //}
    }
}
