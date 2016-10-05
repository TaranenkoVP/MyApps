using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Areas.User.Models.Posts
{
    public class UserEditPostViewModel : IMapFrom<PostBusiness>, IHaveCustomMappings
    {
        public UserEditPostViewModel()
        {
        }

        public UserEditPostViewModel(int topicId)
        {
            TopicId = topicId;
        }

        public int Id { get; set; }

        [Display(Name = "Content")]
        [StringLength(1000, ErrorMessage = "Content must be between 5 and 1000 symbols!", MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int TopicId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PostBusiness, UserEditPostViewModel>();
            configuration.CreateMap<UserEditPostViewModel, PostBusiness>()
                .ForMember(r => r.Author, opts => opts.Ignore())
                .ForMember(r => r.AuthorId, opts => opts.Ignore())
                .ForMember(r => r.CreatedOn, opts => opts.Ignore())
                .ForMember(r => r.TopicId, opts => opts.Ignore());
        }
    }
}