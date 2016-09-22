using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class PostBusiness : BaseModelBusiness<int>, IMapFrom<Post>
    {
        #region Constructors

        //public PostBusiness( )
        //{

        //}

        #endregion Constructors

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public int TopicId { get; set; }

       // .ForMember(r => r.Author, opts => opts.MapFrom(x => x.Author.UserName));
    }
}
