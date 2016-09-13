using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Infrastructure.Mappers;
using MyForum.Web.MVC.Models.TopicCategoriesViewModel;

namespace MyForum.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicCategoriesService _forumCategoriesService;

        public HomeController(ITopicCategoriesService forumCategoriesService)
        {
            this._forumCategoriesService = forumCategoriesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[ChildActionOnly]
        //public ActionResult GetCategoriesPartial()
        //{

            // var categories = new GenericMapper<TopicCategoryBusiness, TopicCategoriesViewModel>().GetWrapped(_forumCategoriesService.GetAll());
            //var forumTopicCategoriesData = new GenericMapper<TopicCategoryBusiness, TopicCategoriesViewModel>(_forumCategoriesService.GetAll());

            //.ProjectTo<TopicCategoriesViewModel>()
            // .ToList();

            //return this.PartialView("_TopicCategoriesPartial", categories);
        //    return View();
        //}
    }
}