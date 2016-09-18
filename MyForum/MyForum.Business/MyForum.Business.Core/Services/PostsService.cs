using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class PostsService : DeletableBaseService<Post, PostBusiness>, IPostsService
    {
        public PostsService(IUnitOfWork uow)
            : base(uow, uow.PostRepository)
        {
            
        }
        public TopicCategoryBusiness GetTopicCategory(int id)
        {

            var topicCategory = Mapper.Map<TopicCategoryBusiness>(
                    Database.TopicCategoryRepository.GetById(id));

            if (topicCategory == null)
            {
                throw new ValidationException("Topic Category not found");
            }

            return topicCategory;
        }

        public PostBusiness GetLastCreated()
        {
            throw new ValidationException("Topic Category not found");
            //var post = Mapper.Map<PostBusiness>(
            //        _database.PostRepository.Get(
            //            filter: d => d. == departmentID,
            //            orderBy: q => q.OrderBy(d => d.CourseID).,
            //            includeProperties: "Department"));
            //            ));

            //if (post == null)
            //{
            //    throw new ValidationException("Post not found");
            //}

            //return post;
        }

    }
}
