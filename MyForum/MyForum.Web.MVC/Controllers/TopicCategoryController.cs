using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicCategoryController : BaseController
    {
        // GET: TopicCategories
        public ActionResult Index()
        {
            return View();
        }
    }
}