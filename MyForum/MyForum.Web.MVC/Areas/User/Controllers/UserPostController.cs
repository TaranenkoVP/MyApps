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
    [Authorize]
    public class UserPostController : BaseController
    {
        private readonly IPostsService _postsService;

        public UserPostController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(UserAddPostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var post = Mapper.Map<PostBusiness>(model);
                post.Content = model.Content;
                post.TopicId = model.TopicId;
                post.AuthorId = User.Identity.GetUserId();
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
                return View("_EditPostPartial", Mapper.Map<UserEditPostViewModel>(post));
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }

        [Authorize]
        [HttpPost]
        [HandleError(View = "Error")]
        public async Task<ActionResult> EditPost(UserEditPostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                try
                {
                    var post = await _postsService.GetByIdAsync(model.Id);
                    Mapper.Map(model, post);
                    var detais = await _postsService.EditAsync(post);
                    if (!detais.Succedeed)
                    {
                        ModelState.AddModelError("", detais.Message);
                    }
                    else
                    {
                        //Success!!!
                        return RedirectToAction("Show", "Topic", new { area = "", id = model.TopicId });
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    View("_EditPostPartial", model);
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