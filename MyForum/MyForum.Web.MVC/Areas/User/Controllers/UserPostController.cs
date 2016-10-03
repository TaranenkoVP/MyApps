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
                var detais = await _postsService.AddAsync(post);
                if (!detais.Succedeed)
                {
                    ModelState.AddModelError("", detais.Message);
                }
                else
                {
                    //Success!!! Reloading all page...
                    return JavaScript("location.reload(true)");
                }
            }
            var error = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            return PartialView("ShowMessage",
                new GenericMessageViewModel {Message = error, MessageType = GenericMessages.Warning});
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditPost(int postId)
        {
            try
            {
                var post = await _postsService.GetByIdAsync(postId);
                return View("_EditPostPartial", Mapper.Map<PostInputModel>(post));
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditPost(PostInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);
                //post.ModifiedOn = DateTime.Now;
                var detais = await _postsService.EditAsync(post);
                if (!detais.Succedeed)
                {
                    ModelState.AddModelError("", detais.Message);
                }
                else
                {
                    //Success!!!
                    return RedirectToAction("Show", "Topic", new {area = "", id = model.TopicId});
                }
            }
            return View("_EditPostPartial", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> DeletePost(int postId, int topicid)
        {
            if (postId == 0)
            {
                return RedirectToAction("Show", "Topic", new {area = "", id = topicid});
            }
            var detais = await _postsService.DeleteByIdAsync(postId);
            if (!detais.Succedeed)
            {
                ModelState.AddModelError("", detais.Message);
            }

            return RedirectToAction("Show", "Topic", new {area = "", id = topicid});
        }

        [Authorize]
        [HttpGet]
        public ActionResult ReplyPost(int postId)
        {
            return View();
        }
    }
}