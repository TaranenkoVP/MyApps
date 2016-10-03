using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Areas.Admin.Models
{
    public class AdminMainCategoriesViewModel : IMapFrom<MainCategoryBusiness>
    {
        [Editable(false)]
        public int Id { get; set; }
        [Editable(true)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}