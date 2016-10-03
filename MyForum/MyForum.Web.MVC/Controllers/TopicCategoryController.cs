using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicCategoryController : BaseController
    {
        // GET: TopicCategories
        private readonly ITopicCategoriesService _topicCategoriesService;
        private readonly ITopicsService _topicsService;

        public TopicCategoryController(ITopicCategoriesService topicCategoriesService, ITopicsService topicsService)
        {
            _topicCategoriesService = topicCategoriesService;
            _topicsService = topicsService;
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var topicCategory = Mapper.Map<TopicCategoriesViewModel>(_topicCategoriesService.GetByIdWithTopics(id));

            return View("TopicCategory", topicCategory);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTopicCategoryPartial(TopicCategoriesViewModel topicCategory)
        {
            return PartialView("_TopicCategoryPartial", topicCategory);
        }
    }
}