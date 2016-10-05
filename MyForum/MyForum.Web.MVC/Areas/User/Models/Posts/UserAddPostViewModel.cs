using System.ComponentModel.DataAnnotations;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Areas.User.Models.Posts
{
    public class UserAddPostViewModel : IMapFrom<PostBusiness>
    {
        public UserAddPostViewModel()
        {
        }

        public UserAddPostViewModel(int topicId)
        {
            TopicId = topicId;
        }

        [Required]
        [Display(Name = "Content")]
        [StringLength(1000, ErrorMessage = "Content must be between 5 and 1000 symbols!", MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int TopicId { get; set; }
    }
}