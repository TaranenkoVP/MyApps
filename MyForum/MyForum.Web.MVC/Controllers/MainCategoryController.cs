using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class MainCategoryController : BaseController
    {
        private readonly IMainCategoriesService _mainCategoriesService;

        public MainCategoryController(IMainCategoriesService mainCategoriesService, ITopicCategoriesService topicCategoriesService)
        {
            this._mainCategoriesService = mainCategoriesService;
        }

        // GET: MainCategory
        [HttpGet]
        public ActionResult Show(int id)
        {
            var mainCategory = Mapper.Map<MainCategoriesViewModel>(_mainCategoriesService.GetById(id));

            return View("MainCategory", mainCategory);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetMainCategoryPartial(MainCategoriesViewModel mainCategory)
        {
            return PartialView("_MainCategoryPartial", mainCategory);
        }
    }
}