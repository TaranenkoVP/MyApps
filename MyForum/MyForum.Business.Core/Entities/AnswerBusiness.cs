using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Business.Core.Entities
{
    public class AnswerBusiness : BaseModel<int>
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public virtual UserBusiness Author { get; set; }

        public virtual PostBusiness Post { get; set; }

    }
}
