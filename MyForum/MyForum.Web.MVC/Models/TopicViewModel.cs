using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Models
{
    public class TopicViewModel : IMapFrom<TopicBusiness>
    {
        public int Id { get; set; }

        public int TopicCategoryId { get; set; }

        public string TopicCategoryName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }


        public PostViewModel LatestPost { get; set; }

        public int PostsCount { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }

        // public IEnumerable<PostViewModel> Answers { get; set; }

        //public TopicCategoriesViewModel Category;


    }
}