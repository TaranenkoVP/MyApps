using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Models
{
    public class PostViewModel : IMapFrom<PostBusiness>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public UserViewModel Author { get; set; }

        public int TopicId { get; set; }

    }
}