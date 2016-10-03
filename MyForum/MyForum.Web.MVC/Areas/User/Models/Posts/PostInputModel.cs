using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Areas.User.Models.Posts
{
    public class PostInputModel : IMapFrom<PostBusiness>
    {
        public PostInputModel()
        {

        }
        public PostInputModel(int topicId)
        {
            this.TopicId = topicId;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Content")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(1000, ErrorMessage = "Content must be between 5 and 1000 symbols!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int TopicId { get; set; }
    }
}