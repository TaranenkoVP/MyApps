using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private const int PageSize = 10;

        private readonly IMainCategoriesService _mainCategoriesService;
        private readonly ITopicCategoriesService _topicCategoriesService;
        private readonly ITopicsService _topicsService;

        public HomeController(IMainCategoriesService mainCategoriesService, ITopicCategoriesService topicCategoriesService, ITopicsService topicsService )
        {
            this._mainCategoriesService = mainCategoriesService;
            this._topicCategoriesService = topicCategoriesService;
            this._topicsService = topicsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetListMainCategoriesPartial()
        {
            var categories = Mapper.Map<List<MainCategoriesViewModel>>(_mainCategoriesService.GetAllWithTopicCategories());

            return PartialView("_MainCategoriesListPartial", categories);

        }
    }
}