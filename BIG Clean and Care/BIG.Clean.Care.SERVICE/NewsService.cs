using BIG.Clean.Care.DAL;
using BIG.Clean.Care.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.Clean.Care.SERVICE
{
    public class NewsService
    {
        ResponseModel resp = new ResponseModel();
        public ResponseModel AddNews(PAGE_CONTENT source)
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    ctx.PAGE_CONTENT.Add(source);
                    ctx.SaveChanges();
                    resp.STATUS = true;
                }
            }
            catch (Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }

            return resp;
        }
        public ResponseModel GetListNew()
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var news = ctx.PAGE_CONTENT.Where(o => o.STATUS == 1).ToList();

                    news.ForEach(o => o.CREATED_BY = o.CREATED_BY + " " + o.CREATED_DATE.ToString());
                    if (news.Count > 0)
                    {
                        resp.STATUS = true;
                        resp.RESULT = news;
                    }
                    else
                    {
                        resp.STATUS = false;
                        resp.MESSAGE = "Not found News";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }

            return resp;
        }
    }
}
