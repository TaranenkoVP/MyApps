using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Data.Core.Common.Repositories
{
    public interface ITopicCategoryRepository : IDeletableEntityRepository<TopicCategory>
    {
        //int GetTopicCountByMainCategoryId(int id);
        //int GetPostCountByMainCategoryId(int id);
        ////Post GetLatestPostByMainCategoryId(int id);
        //int? FindLatestPostIdByMainCategoryId(int id);
    }

}
