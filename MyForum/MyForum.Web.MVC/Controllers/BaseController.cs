using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyForum.Web.MVC.Infrastructure.Mappers;

namespace MyForum.Web.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }


        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        //protected string UserIp
        //{
        //    get
        //    {
        //        return this.Request.UserHostAddress;
        //    }
        //}
    }
}