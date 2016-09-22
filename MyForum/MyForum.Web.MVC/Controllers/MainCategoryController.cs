using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class MainCategoryController : BaseController
    {
        // GET: MainCategory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetListMainCategoriesPartial(MainCategoriesViewModel mainCategory)
        {

            return PartialView("_MainCategoryPartial", mainCategory);

        }
    }
}