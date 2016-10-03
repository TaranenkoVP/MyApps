using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Areas.User.Models.Posts;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicController : BaseController
    {

        private readonly ITopicsService _topicsService;
        private readonly IPostsService _postsService;

        public TopicController( ITopicsService topicsService, IPostsService postsService )
        {
            this._topicsService = topicsService;
            _postsService = postsService;
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var topic = Mapper.Map<TopicViewModel>(_topicsService.GetByIdWithPosts(id));

            return View("Topic", topic);
        }

        [HttpPost]
        public ActionResult InputPostMenu(int topicId)
        {
            return PartialView("~/Areas/User/Views/UserPost/_AddPostPartial.cshtml", new PostInputModel(topicId));
        }


    }
}