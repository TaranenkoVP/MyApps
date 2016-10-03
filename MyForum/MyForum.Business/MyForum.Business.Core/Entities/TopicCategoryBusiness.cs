using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicCategoryBusiness : BaseModelBusiness<int>, IMapFrom<TopicCategory>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MainCategoryId { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public int TopicsCount { get; set; }

        public int PostsCount { get; set; }

        public PostBusiness LatestPost { get; set; }

        public virtual ICollection<TopicBusiness> Topics { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TopicCategory, TopicCategoryBusiness>()
                .ForMember(r => r.AuthorId, opts => opts.MapFrom(x => x.ApplicationUserId))
                .ForMember(r => r.Author, opts => opts.MapFrom(x => x.ApplicationUser));
        }
    }
}