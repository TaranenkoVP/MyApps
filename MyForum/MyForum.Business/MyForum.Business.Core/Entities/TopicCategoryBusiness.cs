using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicCategoryBusiness : BaseModelBusiness<int>, IMapFrom<TopicCategory>, IHaveCustomMappings
    {
        private ICollection<TopicBusiness> _topics;

        public TopicCategoryBusiness()
        {
            _topics = new HashSet<TopicBusiness>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MainCategoryId { get; set; }

        public virtual MainCategory MainCategory { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public int TopicsCount { get; set; }

        public int PostsCount { get; set; }

        public PostBusiness LatestPost { get; set; }

        public virtual ICollection<TopicBusiness> Topics
        {
            get { return _topics; }
            set { _topics = value; }
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TopicCategory, TopicCategoryBusiness>();
            //   .ForMember(r => r.TopicsCount, opts => opts.MapFrom(x => x.Topics.Count));
            //       .ForMember(r => r.PostsCount, opts => opts.MapFrom(x => x.Topics.SelectMany(y => y.Posts).Count()))
            //       .ForMember(r => r.LatestPost,
            //            opts => opts.MapFrom(x => x.Topics.Select(y => y.Posts.OrderByDescending(t => t.CreatedOn).FirstOrDefault())));
        }
    }
}