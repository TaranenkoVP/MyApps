using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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
        private readonly IPostsService _postsService;

        public UserPostController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        // GET: User/UserPost
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPost(PostInputModel model)
        {
            var userId = User.Identity.GetUserId();
            if (model != null && ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);
                post.Content = model.Content;
                post.TopicId = model.TopicId;
                post.AuthorId = userId;
                post.CreatedOn = DateTime.UtcNow;
                await _postsService.AddAsync(post);
                return JavaScript("location.reload(true)");
            }
            var error = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            return PartialView("ShowMessage",
                new GenericMessageViewModel {Message = error, MessageType = GenericMessages.Warning});
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditPost(int postId)
        {
            var post = Mapper.Map<PostInputModel>(_postsService.GetByIdAsync(postId));
            return View("_EditPostPartial", post);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPost(PostInputModel model)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);
                _postsService.EditAsync(post);
                return RedirectToAction("Show", "Topic", new {area = "", id = model.TopicId});
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