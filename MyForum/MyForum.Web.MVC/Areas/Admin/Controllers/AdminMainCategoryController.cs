using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using MyForum.Web.MVC.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Areas.Admin.Models;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminMainCategoryController : BaseController
    {
        private readonly IMainCategoriesService _mainCategoriesService;

        public AdminMainCategoryController(IMainCategoriesService mainCategoriesService)
        {
            _mainCategoriesService = mainCategoriesService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public async Task<ActionResult> MainCategories_Read([DataSourceRequest]DataSourceRequest request)
        {
            var categories = await _mainCategoriesService.GetAllAsync();
            DataSourceResult result =categories.ToDataSourceResult(
                request, domain => Mapper.Map<AdminMainCategoriesViewModel>(domain));
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> MainCategories_Create([DataSourceRequest]DataSourceRequest request, AdminMainCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new MainCategoryBusiness
                {
                    Name = category.Name,
                    Description = category.Description
                };
                await _mainCategoriesService.AddAsync(entity);
                category.Id = entity.Id;
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> MainCategories_Update([DataSourceRequest]DataSourceRequest request, AdminMainCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoriesToEdit = await _mainCategoriesService.GetAllAsync();
                var categoryToEdit = categoriesToEdit.FirstOrDefault(c => c.Id == category.Id);
                if (categoryToEdit == null)
                {
                    return null;
                }
                categoryToEdit.Name = category.Name;
                categoryToEdit.Description = category.Description;
                await _mainCategoriesService.EditAsync(categoryToEdit);
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> MainCategories_Destroy([DataSourceRequest]DataSourceRequest request, AdminMainCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<MainCategoryBusiness>(category);
                await _mainCategoriesService.DeleteAsync(entity);
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }
    }
}