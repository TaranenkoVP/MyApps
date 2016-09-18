using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Models;

namespace MyForum.Data.Core.Common.Repositories
{
    public interface ITopicCategoryRepository : IDeletableEntityRepository<TopicCategory>
    {
    }
}
