using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMainCategoriesService _mainCategoriesService;

        public HomeController(IMainCategoriesService mainCategoriesService)
        {
            _mainCategoriesService = mainCategoriesService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _mainCategoriesService.GetAllWithTopicCategoriesAsync();
            return View("_MainCategoriesListPartial", Mapper.Map<List<MainCategoriesViewModel>>(categories));
        }
    }
}