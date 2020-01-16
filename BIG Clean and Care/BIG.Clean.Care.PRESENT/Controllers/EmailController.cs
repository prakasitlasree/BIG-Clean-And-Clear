using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using BIG.Clean.Care.MODEL;
using System.Web.Configuration;

namespace BIG.Clean.Care.PRESENT.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        public JsonResult SendMail()
        {
            ResponseModel resp = new ResponseModel();
            var fromAddress = new MailAddress("bigcleancare2020@gmail.com", "https://www.bigcleanandcare.com");
            var toAddress = new MailAddress("bigcleancare2020@gmail.com", "https://www.bigcleanandcare.com");
            string fromPassword = WebConfigurationManager.AppSettings["password"].ToString();
            const string subject = "ขอข้อมูลการติดต่อจาก เว็บไซต์ www.bigcleanandcare.com";

            var NAME = Request.Form["NAME"].ToString();
            var TEL = Request.Form["TEL"].ToString();
            var EMAIL = Request.Form["EMAIL"].ToString();
            var MESSAGE = Request.Form["MESSAGE"].ToString();

            string body = @"ชื่อ: " + NAME + Environment.NewLine + Environment.NewLine +
                            " อีเมลล์: " + EMAIL + Environment.NewLine + Environment.NewLine +
                            " เบอร์โทร: " + TEL + Environment.NewLine + Environment.NewLine +
                            " ข้อความ: " + MESSAGE + Environment.NewLine + Environment.NewLine +
                            Environment.NewLine +
                            Environment.NewLine +
                            "Best Regard" + Environment.NewLine +
                            "www.bigcleanandcare.com";


            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential()
                    {
                        UserName = "bigcleancare2020@gmail.com",
                        Password = "@bigCC191",
                    };
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;

                    //Oops: from/recipients switched around here...
                    //smtpClient.Send("targetemail@targetdomain.xyz", "myemail@gmail.com", "Account verification", body);
                    smtpClient.Send("bigcleancare2020@gmail.com", "bigcleancare2020@gmail.com", subject, body);
                    smtpClient.Send("bigcleancare2020@gmail.com", "bigcleanandcareservices@gmail.com", subject, body);
                    //smtpClient.Send("bigcleancare2020@gmail.com", "natchaphon2140@gmail.com", subject, body);
                    smtpClient.Send("bigcleancare2020@gmail.com", "prakasitlasree@gmail.com", subject, body);

                    resp.STATUS = true;
                }
            }
            catch (Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }


            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}