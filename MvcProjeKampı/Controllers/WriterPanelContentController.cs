using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["writerMail"];
            var writerIdInfo = c.writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var contentValue = cm.GetListByWriter(writerIdInfo);
            return View(contentValue);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.contentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["writerMail"];
            var writerIdInfo = c.writers.Where(x => x.writerMail == mail).Select(y => y.writerId).FirstOrDefault();
            p.writerId = writerIdInfo;
            p.contentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}