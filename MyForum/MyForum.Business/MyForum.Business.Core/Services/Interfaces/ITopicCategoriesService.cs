using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicCategoriesService : IBaseService<TopicCategory, TopicCategoryBusiness>
    {
        IEnumerable<TopicCategoryBusiness> GetAll();
        //void Add(TopicCategoryBusiness entity);
        //void Update(TopicCategoryBusiness entity);
        //void Delete(TopicCategoryBusiness entity);
    }
}
