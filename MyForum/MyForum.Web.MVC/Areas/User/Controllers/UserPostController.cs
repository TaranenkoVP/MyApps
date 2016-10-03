using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Areas.User.Models.Posts;
using MyForum.Web.MVC.Controllers;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Areas.User.Controllers
{
    public class UserPostController : BaseController
    {
        private readonly ITopicsService _topicsService;
        private readonly IPostsService _postsService;

        public UserPostController(ITopicsService topicsService, IPostsService postsService)
        {
            this._topicsService = topicsService;
            _postsService = postsService;
        }

        // GET: User/UserPost
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPost(PostInputModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (model != null && ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);

                post.Content = model.Content;
                post.TopicId = model.TopicId;
                post.AuthorId = userId;
                post.CreatedOn = DateTime.UtcNow;

                _postsService.Add(post);
               // return Redirect("/Topic/Show/" + model.TopicId);
                return JavaScript("location.reload(true)");
            }
            var error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            return PartialView("ErrorMessage", new GenericMessageViewModel() { Message = error, MessageType = GenericMessages.Warning});
        }


        [Authorize]
        [HttpGet]
        public ActionResult EditPost(int postId)
        {
            var post = Mapper.Map<PostInputModel>(_postsService.GetById(postId));

            return View("_EditPostPartial", post);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPost(PostInputModel model)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);
                _postsService.Update(post);
                return RedirectToAction("Show", "Topic", new { area = "", id = model.TopicId });
            }

           // ModelState.AddModelError("", "Invalid text!");

            return View("_EditPostPartial", model);
        }


        [Authorize]
        [HttpGet]
        public ActionResult DeletePost(int postId)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ReplyPost(int postId)
        {
            return View();
        }
    }
}