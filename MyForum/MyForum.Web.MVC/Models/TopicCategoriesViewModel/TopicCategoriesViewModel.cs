using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyForum.Business.Core.Entities;

namespace MyForum.Web.MVC.Models.TopicCategoriesViewModel
{
    public class TopicCategoriesViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}