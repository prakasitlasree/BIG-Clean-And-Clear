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

        public ResponseModel EditNews(PAGE_CONTENT source)
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var obj = ctx.PAGE_CONTENT.Where(o=>o.ID == source.ID).First();
                    if(obj != null)
                    {
                        obj.SECTION_NAME = source.SECTION_NAME;
                        obj.HTML_SUB_HEADER1 = source.HTML_SUB_HEADER1;
                        obj.HTML_VALUE = source.HTML_VALUE;
                        if(source.IMAGE_URL1 != null)
                        {
                            obj.IMAGE_URL1 = source.IMAGE_URL1;
                            obj.IMAGE_URL2 = source.IMAGE_URL2;
                        }
                        ctx.SaveChanges();
                        resp.STATUS = true;
                    }
                    else
                    {
                        resp.ERROR_MESSAGE = "ไม่พบข้อมูล";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }

            return resp;
        }


        public ResponseModel DeleteNews(int id)
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var obj = ctx.PAGE_CONTENT.Where(o => o.ID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        ctx.PAGE_CONTENT.Remove(obj);
                        ctx.SaveChanges();
                        resp.STATUS = true;
                    }
                    else
                    {
                        resp.ERROR_MESSAGE = "เกิดข้อผิดพลาดกรุณารีเฟรชหน้าเว็บอีกครั้ง";
                        resp.STATUS = false;
                    }
                 
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
        public ResponseModel GetNews(int id)
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var obj = ctx.PAGE_CONTENT.Where(o => o.ID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        resp.RESULT = obj;
                        resp.STATUS = true;
                    }
                    else
                    {
                        resp.ERROR_MESSAGE = "เกิดข้อผิดพลาดกรุณารีเฟรชหน้าเว็บอีกครั้ง";
                        resp.STATUS = false;
                    }

                }
            }
            catch (Exception ex)
            {
                resp.ERROR_MESSAGE = ex.Message;
            }

            return resp;
        }
        public ResponseModel GetListNewTable()
        {
            try
            {
                using (BIGCCEntities ctx = new BIGCCEntities())
                {
                    var news = ctx.PAGE_CONTENT.Where(o => o.STATUS == 1).ToList();

                    var listdata = news.Select(o => new
                    {
                        ID = o.ID,
                        Header = o.SECTION_NAME,
                        SubHeader = o.HTML_SUB_HEADER1,
                        Value = o.HTML_VALUE,
                        Picture = o.IMAGE_URL2

                    }).ToList();

                    if (listdata.Count > 0)
                    {
                        resp.STATUS = true;
                        resp.RESULT = listdata;
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
