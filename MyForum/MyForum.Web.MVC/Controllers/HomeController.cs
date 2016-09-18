using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models.Post;
using MyForum.Web.MVC.Models.TopicCategories;

namespace MyForum.Web.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITopicCategoriesService _topicCategoriesService;
        private readonly ITopicsService _topicsService;

        public HomeController(ITopicCategoriesService topicCategoriesService, ITopicsService topicsService)
        {
            this._topicCategoriesService = topicCategoriesService;
            this._topicsService = topicsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTopicCategoriesPartial()
        {
            var viewModel = new List<TopicCategoriesViewModel>();

            var categories = Mapper.Map<List<TopicCategoriesViewModel>>(_topicCategoriesService.GetAll());

            foreach (var category in categories)
            {

                var f = _topicsService.GetLastCreatedByCategoryId(category.Id);
                var lastPost = Mapper.Map<PostViewModel>(f
                                    );


                var model = new TopicCategoriesViewModel
                {

                    //Category = category,
                    //LatestTopic = latestTopicInCategory,
                    //Permissions = permissionSet,
                    //PostCount = postCount,
                    //TopicCount = topicCount,
                    //ShowUnSubscribedLink = true
                };
                viewModel.Add(model);
            }

            

            

            return this.PartialView("_TopicCategoriesPartial", categories);

        }
    }
}