using System.Threading.Tasks;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class MainCategoryController : BaseController
    {
        private readonly IMainCategoriesService _mainCategoriesService;

        public MainCategoryController(IMainCategoriesService mainCategoriesService)
        {
            _mainCategoriesService = mainCategoriesService;
        }

        // GET: MainCategory
        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            var mainCategory = await _mainCategoriesService.GetByIdWithTopicCategoriesAsync(id);
            return View("MainCategory", Mapper.Map<MainCategoriesViewModel>(mainCategory));
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetMainCategoryPartial(MainCategoriesViewModel mainCategory)
        {
            return PartialView("_MainCategoryPartial", mainCategory);
        }
    }
}