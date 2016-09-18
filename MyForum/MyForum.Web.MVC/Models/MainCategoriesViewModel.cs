using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Models
{
    public class MainCategoriesViewModel : IMapFrom<MainCategoryBusiness>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public TopicViewModel LatestPost { get; set; }
        public int TopicCount { get; set; }
        public int PostCount { get; set; }

        public IEnumerable<TopicCategoriesViewModel> TopicCategories { get; set; }

        public DateTime Latest { get; set; }
    }
}