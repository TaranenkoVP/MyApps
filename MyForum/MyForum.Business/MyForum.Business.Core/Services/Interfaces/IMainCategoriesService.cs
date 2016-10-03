using System.Collections.Generic;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IMainCategoriesService : IEntityService
    {
        Task<MainCategoryBusiness> GetByIdAsync(int id);
        Task<IEnumerable<MainCategoryBusiness>> GetAllAsync();
        Task<MainCategoryBusiness> GetByIdWithTopicCategoriesAsync(int id);
        Task<IEnumerable<MainCategoryBusiness>> GetAllWithTopicCategoriesAsync();
        Task<MainCategoryBusiness> AddAsync(MainCategoryBusiness entity);
        Task<MainCategoryBusiness> EditAsync(MainCategoryBusiness entity);
        Task<MainCategoryBusiness> DeleteAsync(MainCategoryBusiness entity);
    }
}