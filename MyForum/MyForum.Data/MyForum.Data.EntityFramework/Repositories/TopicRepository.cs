using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using MyForum.Data.EF.Repositories.Common;

namespace MyForum.Data.EF.Repositories
{
    public class TopicRepository : DeletableEntityRepository<Topic>, ITopicRepository
    {
        public TopicRepository(DbContext context)
            : base(context)
        {
        }

        public int GetCountByCategoryId(int id)
        {
            return DbSet.Count(d => (d.TopicCategory.Id == id) && (!d.IsDeleted));
        }

        //public int GetLatestPostByCategoryId(int id)
        //{
        //    return DbSet.Posts (d => (d.TopicCategory.Id == id) && (!d.IsDeleted));
        //}
    }
}
