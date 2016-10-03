using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;

namespace MyForum.Web.MVC.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostsService _postsService;

        public PostController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}