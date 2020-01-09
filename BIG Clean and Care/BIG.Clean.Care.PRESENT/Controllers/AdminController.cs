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
            if(Session["User"] == null)
            {
                return RedirectToAction("loginpage", "admin");
            }
            else
            {
                return RedirectToAction("ManagementPage", "admin");
            }
            
        }

        public ActionResult ManagementPage()
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

        [HttpPost]
        public JsonResult AddNews()
        {
            
            ResponseModel resp = new ResponseModel();
            HttpFileCollectionBase files = Request.Files ;
            var header = Request.Form["SECTION_NAME"].ToString();
            var subHeader = Request.Form["HTML_SUB_HEADER1"].ToString();
            var content = Request.Form["HTML_VALUE"].ToString();
            

            var pathFolder= Server.MapPath("~/assets/images/news");
            var pathfile = "";
            var fileName = "";
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                pathfile = Path.Combine(pathFolder, file.FileName);
                fileName = file.FileName;
                file.SaveAs(pathfile);
               
            }

            NewsService service = new NewsService();

            if(Session["User"] != null)
            {
                var obj = (LOGON)Session["User"];
                PAGE_CONTENT source = new PAGE_CONTENT()
                {
                    MODULE = "News",
                    SECTION_NAME = header,
                    HTML_SUB_HEADER1 = subHeader,
                    HTML_VALUE = content,
                    STATUS = 1,
                    IMAGE_URL1 = pathfile,
                    IMAGE_URL2 = fileName,
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now,
                    CREATED_BY = obj.USERNAME,
                    UPDATED_BY = obj.USERNAME
                };

                resp = service.AddNews(source);
            }
            else
            {
                resp.STATUS = false;
                resp.ERROR_MESSAGE = "กรุณาเข้าสู่ระบบใหม่";
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