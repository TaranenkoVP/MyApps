using System.Data.Entity;
using System.Linq;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using MyForum.Data.EF.Repositories.Common;

namespace MyForum.Data.EF.Repositories
{
    public class TopicCategoryRepository : DeletableEntityRepository<TopicCategory>, ITopicCategoryRepository
    {
        public TopicCategoryRepository(DbContext context) : base(context)
        {
        }

        //public int GetTopicCountByMainCategoryId(int id)
        //{
        //    var count = DbSet.Where(x => x.MainCategory.Id == id)
        //        .Select(x => x.Topics.Count)
        //        .Sum();

        //    return count;
        //}

        //public int GetPostCountByMainCategoryId(int id)
        //{
        //    var count = DbSet.Where(x => x.MainCategory.Id == id)
        //        .Select(x => x.Topics.SelectMany(y => y.Posts)
        //            .Count())
        //        .Sum();

        //    return count;
        //}


        //public Post GetLatestPostByMainCategoryId(int id)
        //{
        //    var post = DbSet.Where(x => x.MainCategory.Id == id)
        //        .Select(x => x.Topics.SelectMany(y => y.Posts)
        //            .OrderByDescending(y => y.CreatedOn)
        //            .FirstOrDefault())
        //        .Include(x => x.Content)
        //        .Include(x => x.Author)
        //        .Include(x => x.Author.UserName)
        //        .Include(x => x.CreatedOn)
        //        .FirstOrDefault();

        //    return post;
        //}

        //public int? FindLatestPostIdByMainCategoryId(int id)
        //{
        //    var post = DbSet.Where(x => x.MainCategory.Id == id)
        //        .Select(x => x.Topics.SelectMany(y => y.Posts)
        //            .OrderByDescending(y => y.CreatedOn)
        //            .FirstOrDefault())
        //        .FirstOrDefault();

        //    return post?.Id;
        //}
    }
}