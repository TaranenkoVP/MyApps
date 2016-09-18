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
    public class TopicCategoryBusiness : BaseModelBusiness<int>, IMapFrom<TopicCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual MainCategory MainCategory{ get; set; }

        public virtual UserBusiness Author { get; set; }

        public virtual PostBusiness Post { get; set; }

    }
}
