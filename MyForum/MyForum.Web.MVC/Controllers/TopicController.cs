using System.Threading.Tasks;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Areas.User.Models.Posts;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class TopicController : BaseController
    {
        private readonly ITopicCategoriesService _topicCategoriesService;
        private readonly ITopicsService _topicsService;

        public TopicController(ITopicsService topicsService, ITopicCategoriesService topicCategoriesService)
        {
            _topicsService = topicsService;
            _topicCategoriesService = topicCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            var topic = Mapper.Map<TopicViewModel>(await _topicsService.GetByIdWithPostsAsync(id));
            var topicCategory = await _topicCategoriesService.GetByIdAsync(topic.TopicCategoryId);
            topic.TopicCategoryName = topicCategory.Name;
            return View("Topic", topic);
        }

        [HttpPost]
        public ActionResult InputPostMenu(int topicId)
        {
            return PartialView("~/Areas/User/Views/UserPost/_AddPostPartial.cshtml", new PostInputModel(topicId));
        }
    }
}