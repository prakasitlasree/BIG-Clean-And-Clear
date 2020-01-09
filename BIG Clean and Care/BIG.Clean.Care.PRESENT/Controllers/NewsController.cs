using BIG.Clean.Care.MODEL;
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

       

    }
}