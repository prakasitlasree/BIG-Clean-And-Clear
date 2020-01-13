﻿using BIG.Clean.Care.MODEL;
using BIG.Clean.Care.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG.Clean.Care.PRESENT.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListNew()
        {
            var service = new NewsService();
            var resp = service.GetListNew();          
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListNewTable()
        {
            var service = new NewsService();
            var resp = service.GetListNewTable();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult Delete(int id)
        {
            var service = new NewsService();
            var resp = service.DeleteNews(id);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }




    }
}