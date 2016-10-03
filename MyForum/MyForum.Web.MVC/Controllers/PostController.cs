using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Areas.User.Models.Posts;

namespace MyForum.Web.MVC.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostsService _postsService;

        public PostController(IPostsService postsService)
        {
            _postsService = postsService;
        }


        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}