using System.Collections.Generic;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicCategoriesService : IDeletable<TopicCategoryBusiness>
    {
        IEnumerable<TopicCategoryBusiness> GetAll();
        TopicCategoryBusiness GetByIdWithTopics(int id);
        IEnumerable<TopicCategoryBusiness> GetAllWithTopics();
    }
}