using System.Collections.Generic;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IMainCategoriesService : IEntityService
    {
        Task<MainCategoryBusiness> GetByIdAsync(int id);
        Task<IEnumerable<MainCategoryBusiness>> GetAllAsync();
        Task<MainCategoryBusiness> GetByIdWithTopicCategoriesAsync(int id);
        Task<IEnumerable<MainCategoryBusiness>> GetAllWithTopicCategoriesAsync();
        Task<OperationDetails> AddAsync(MainCategoryBusiness entity);
        Task<OperationDetails> EditAsync(MainCategoryBusiness entity);
        Task<OperationDetails> DeleteAsync(MainCategoryBusiness entity);
    }
}