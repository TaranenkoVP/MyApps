using System.Collections.Generic;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IMainCategoriesService : IDeletable<MainCategoryBusiness>
    {
        IEnumerable<MainCategoryBusiness> GetAll();
        IEnumerable<MainCategoryBusiness> GetAllWithTopicCategories();
        MainCategoryBusiness GetById(int id);
        MainCategoryBusiness GetByIdWithTopicCategories(int id);
    }
}