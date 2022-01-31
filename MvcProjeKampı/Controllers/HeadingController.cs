using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValue = hm.GetList();
            return View(headingValue);
        }
        public ActionResult HeadingReport()
        {
            var headingValue = hm.GetList();
            return View(headingValue);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();
            ViewBag.vlC = valueCategory;

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.writerName +" "+ x.writerSurName,
                                                    Value = x.writerId.ToString()
                                                }).ToList();
            ViewBag.vlW = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.headingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();
            ViewBag.vlC = valueCategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.headingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.headingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

    }
   
}