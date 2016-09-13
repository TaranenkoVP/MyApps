using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using MyForum.Business.Core.Entities;

namespace MyForum.Web.MVC.Infrastructure.Mappers
{
    public class GenericMapper<TSource, TDestination>
    {
        private readonly IMapper _genericMapper;

        public GenericMapper()
        {
            _genericMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();

                cfg.CreateMap<TDestination, TSource>();

            }).CreateMapper();
        }

        public TDestination GetWrapped(TSource topicCategory)
        {
            return _genericMapper.Map<TSource, TDestination>(topicCategory);
        }

        public List<TDestination> GetWrapped(IEnumerable<TSource> topicCategories)
        {
            return _genericMapper.Map<IEnumerable<TSource>, List<TDestination>>(topicCategories);
        }

        public TSource GetWrapped(TDestination topicCategory)
        {
            return _genericMapper.Map<TDestination, TSource>(topicCategory);
        }

    }
}