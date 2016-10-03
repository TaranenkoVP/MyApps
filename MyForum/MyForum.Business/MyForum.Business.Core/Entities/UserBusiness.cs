using System;
using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Business.Core.Entities
{
    public class UserBusiness : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Photo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public List<string> Roles { get; set; }

        public string PasswordHash { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserBusiness>()
               .ForMember(r => r.Roles, opts => opts.MapFrom(x => x.Roles));
            //       .ForMember(r => r.PostsCount, opts => opts.MapFrom(x => x.Topics.SelectMany(y => y.Posts).Count()))
            //       .ForMember(r => r.LatestPost,
            //            opts => opts.MapFrom(x => x.Topics.Select(y => y.Posts.OrderByDescending(t => t.CreatedOn).FirstOrDefault())));
        }
    }
}