using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class PostBusiness : BaseModelBusiness<int>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public int TopicId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostBusiness>()
                .ForMember(r => r.AuthorId, opts => opts.MapFrom(x => x.ApplicationUserId))
                .ForMember(r => r.Author, opts => opts.MapFrom(x => x.ApplicationUser));
            configuration.CreateMap<PostBusiness, Post>()
                .ForMember(r => r.ApplicationUserId, opts => opts.MapFrom(x => x.AuthorId))
                .ForMember(r => r.ApplicationUser, opts => opts.Ignore())
                .ForMember(r => r.Topic, opts => opts.Ignore())
                .ForMember(r => r.CreatedOn, opts => opts.Ignore());
        }
    }
}