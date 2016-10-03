using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicBusiness : BaseModelBusiness<int>, IMapFrom<Topic>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public int TopicCategoryId { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public PostBusiness LatestPost { get; set; }

        public int PostsCount { get; set; }

        public virtual ICollection<PostBusiness> Posts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Topic, TopicBusiness>()
                .ForMember(r => r.AuthorId, opts => opts.MapFrom(x => x.ApplicationUserId))
                .ForMember(r => r.Author, opts => opts.MapFrom(x => x.ApplicationUser));
            configuration.CreateMap<TopicBusiness, Topic>()
                .ForMember(r => r.ApplicationUserId, opts => opts.MapFrom(x => x.AuthorId))
                .ForMember(r => r.ApplicationUser, opts => opts.Ignore())
                .ForMember(r => r.Posts, opts => opts.Ignore())
                .ForMember(r => r.TopicCategory, opts => opts.Ignore());
        }
    }
}