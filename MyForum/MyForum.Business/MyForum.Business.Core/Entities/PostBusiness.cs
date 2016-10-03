using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class PostBusiness : BaseModelBusiness<int>, IMapFrom<Post>
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public int TopicId { get; set; }
    }
}