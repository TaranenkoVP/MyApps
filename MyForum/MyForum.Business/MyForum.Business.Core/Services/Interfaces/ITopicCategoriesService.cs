using System.Collections.Generic;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicCategoriesService : IEntityService
    {
        Task<IEnumerable<TopicCategoryBusiness>> GetAllAsync();
        Task<TopicCategoryBusiness> GetByIdAsync(int id);
        Task<TopicCategoryBusiness> GetByIdWithTopicsAsync(int id);
        Task<IEnumerable<TopicCategoryBusiness>> GetAllWithTopicsAsync();
        Task<TopicCategoryBusiness> AddAsync(TopicCategoryBusiness topicCategoryBusiness);
        Task<TopicCategoryBusiness> EditAsync(TopicCategoryBusiness topicCategoryBusiness);
        Task<TopicCategoryBusiness> DeleteAsync(TopicCategoryBusiness topicCategoryBusiness);
    }
}