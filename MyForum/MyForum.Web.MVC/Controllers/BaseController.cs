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
                return AutoMapperConfigViewModel.Configuration.CreateMapper();
            }
        }

        internal ActionResult ErrorToHomePage(string errorMessage)
        {
            // Use temp data as its a redirect
            //TempData[AppConstants.MessageViewBagName] = new GenericMessageViewModel
            //{
            //    Message = errorMessage,
            //    MessageType = GenericMessages.danger
            //};
            // Not allowed in here so
            return RedirectToAction("Index", "Home");
        }
    }
}