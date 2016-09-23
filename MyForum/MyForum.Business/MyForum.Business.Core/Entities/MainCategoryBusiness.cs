using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class MainCategoryBusiness : IMapFrom<MainCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        private ICollection<TopicCategoryBusiness> _topicCategories;

        /// <summary>
        /// The class constructor
        /// </summary>
        public MainCategoryBusiness()
        {
            _topicCategories = new HashSet<TopicCategoryBusiness>();
        }

        public virtual ICollection<TopicCategoryBusiness> TopicCategories
        {
            get { return this._topicCategories; }
            set { this._topicCategories = value; }
        }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<TopicCategory, TopicCategoryBusiness>()
        //       .ForMember(r => r.TopicsCount, opts => opts.MapFrom(x => x.Topics.Count))
        //       .ForMember(r => r.PostsCount, opts => opts.MapFrom(x => x.Topics.SelectMany(y => y.Posts).Count()))
        //       .ForMember(r => r.LatestPost,
        //            opts => opts.MapFrom(x => x.Topics.Select(y => y.Posts.OrderByDescending(t => t.CreatedOn).FirstOrDefault())));

        //}
    }
}
