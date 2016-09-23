using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Models
{
    public class TopicCategoriesViewModel : IMapFrom<TopicCategoryBusiness>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TopicsCount { get; set; }
        public int PostsCount { get; set; }

        //public TopicViewModel LatestTopic { get; set; }
        public IEnumerable<TopicViewModel> Topics { get; set; }

        public PostViewModel LatestPost { get; set; }

    }
}