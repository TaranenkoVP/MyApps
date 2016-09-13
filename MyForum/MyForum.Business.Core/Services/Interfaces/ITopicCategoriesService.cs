using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicCategoriesService
    {
        IEnumerable<TopicCategoryBusiness> GetAll();
        void Add(TopicCategoryBusiness entity);
        void Update(TopicCategoryBusiness entity);
        void Delete(TopicCategoryBusiness entity);
    }
}
