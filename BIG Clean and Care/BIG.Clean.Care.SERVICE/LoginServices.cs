using BIG.Clean.Care.DAL;
using BIG.Clean.Care.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.Clean.Care.SERVICE
{
    public class LoginServices
    {
        ResponseModel resp = new ResponseModel();
        public ResponseModel Login(LOGON logon)
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var user = ctx.LOGON.Where(o => o.USERNAME == logon.USERNAME && o.PASSWORD == logon.PASSWORD).FirstOrDefault();
                    if (user != null)
                    {
                        resp.STATUS = true;
                        resp.RESULT = user;
                    }
                    else
                    {
                        resp.STATUS = false;
                        resp.ERROR_MESSAGE = "ไม่พบผู้ใช้งาน";
                    }
                }
            }
            catch(Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }

            return resp;
           
        }
    }
}
