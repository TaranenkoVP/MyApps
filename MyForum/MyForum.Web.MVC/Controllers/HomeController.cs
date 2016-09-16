using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Infrastructure.Mappers;
using MyForum.Web.MVC.Models.TopicCategoriesViewModel;

namespace MyForum.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicCategoriesService _topicCategoriesService;

        public HomeController(ITopicCategoriesService topicCategoriesService)
        {
            this._topicCategoriesService = topicCategoriesService;
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTopicCategoriesPartial()
        {

            var categories = new GenericMapper<TopicCategoryBusiness, TopicCategoriesViewModel>()
                    .GetWrapped(_topicCategoriesService.GetAll());

            return this.PartialView("_TopicCategoriesPartial", categories);

        }
    }
}