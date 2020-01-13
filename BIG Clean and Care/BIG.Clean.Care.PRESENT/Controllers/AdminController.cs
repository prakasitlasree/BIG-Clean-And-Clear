using BIG.Clean.Care.MODEL;
using BIG.Clean.Care.SERVICE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG.Clean.Care.PRESENT.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("loginpage", "admin");
            }
            else
            {
                return RedirectToAction("news", "admin");
            }

        }

        public ActionResult AddPage()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("loginpage", "admin");
            }
            else
            {
                LOGON user = (LOGON)Session["User"];
                return View(user);
            }
        }

        public ActionResult EditPage()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("loginpage", "admin");
            }
            else
            {
                LOGON user = (LOGON)Session["User"];
                return View(user);
            }
        }

        public ActionResult News()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("loginpage", "admin");
            }
            else
            {
                LOGON user = (LOGON)Session["User"];
                return View(user);
            }
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public JsonResult Login(LOGON logon)
        {
            var service = new LoginServices();
            var resp = service.Login(logon);
            if (resp.STATUS)
            {
                Session["User"] = resp.RESULT;
            }
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("loginpage", "admin");
        }
    }
}