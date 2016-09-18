using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;
using MyForum.Data.EF.Repositories.Common;

namespace MyForum.Data.EF.Repositories
{
    public class PostRepository : DeletableEntityRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {
        }
    }
}
