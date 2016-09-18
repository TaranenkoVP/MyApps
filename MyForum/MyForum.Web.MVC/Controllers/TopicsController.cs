using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicsController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }
    }
}