using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public TopicCategoryController(ITopicCategoriesService topicCategoriesService)
        {
            _topicCategoriesService = topicCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            var topicCategory = await _topicCategoriesService.GetByIdWithTopicsAsync(id);
            return View("TopicCategory", Mapper.Map<TopicCategoriesViewModel>(topicCategory));
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTopicCategoryPartial(TopicCategoriesViewModel topicCategory)
        {
            return PartialView("_TopicCategoryPartial", topicCategory);
        }
    }
}