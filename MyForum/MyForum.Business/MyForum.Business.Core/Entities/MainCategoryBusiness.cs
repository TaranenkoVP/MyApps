using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Business.Core.Entities
{
    public class MainCategoryBusiness : IMapFrom<MainCategory>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public virtual ICollection<TopicCategoryBusiness> TopicCategories { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MainCategory, MainCategoryBusiness>()
               .ForMember(r => r.AuthorId, opts => opts.MapFrom(x => x.ApplicationUserId))
               .ForMember(r => r.Author, opts => opts.MapFrom(x => x.ApplicationUser));
        }
    }
}