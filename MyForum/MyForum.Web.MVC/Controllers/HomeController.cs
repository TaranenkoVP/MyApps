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
        public ActionResult GetMainCategoriesPartial()
        {
            var categories = Mapper.Map<List<MainCategoriesViewModel>>(_mainCategoriesService.GetAll());

            foreach (var category in categories)
            {
                
                //var topicCategories = Mapper.Map<TopicViewModel>(_topicsService.GetLastCreatedByCategoryId(category.Id));
               // var topicCategories = Mapper.Map<List<TopicCategoriesViewModel>>(_topicCategoriesService.GetAll());
                //var topicCategories = Mapper.Map<List<TopicCategoriesViewModel>>(_topicCategoriesService.GetAll());

                //foreach (var topiccategory in topicCategories)
                //{

                //}




                //var lastPost = Mapper.Map<TopicViewModel>(_topicsService.GetLastCreatedByCategoryId(category.Id));

                //category.LatestPost = lastPost;

                //category.TopicCount = _topicsService.GetCountByCategoryId(category.Id);


                //var model = new TopicCategoriesViewModel
                //{


                //public int Id { get; set; }

                //public string Name { get; set; }

                //public string Description { get; set; }

                ////public TopicViewModel LatestTopic { get; set; }
                //public TopicViewModel LatestPost { get; set; }
                //public int TopicCount { get; set; }
                //public int PostCount { get; set; }

            }
           

            return this.PartialView("_MainCategoriesPartial", categories);

        }
    }
}