using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicController : BaseController
    {

        private readonly ITopicsService _topicsService;

        public TopicController( ITopicsService topicsService)
        {
            this._topicsService = topicsService;
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var topic = Mapper.Map<TopicViewModel>(_topicsService.GetById(id));

            return View("Topic", topic);
        }

    }
}