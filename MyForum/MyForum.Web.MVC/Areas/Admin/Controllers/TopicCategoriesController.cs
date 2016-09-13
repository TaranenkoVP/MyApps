using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyForum.Web.MVC.Areas.Admin.Controllers
{
    public class TopicCategoriesController : Controller
    {
        // GET: Admin/TopicCategories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/TopicCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/TopicCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TopicCategories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TopicCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/TopicCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TopicCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/TopicCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
