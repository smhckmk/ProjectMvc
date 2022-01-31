using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampı.Controllers
{
    public class WriterPanelController : Controller
    {

    //    <customErrors mode = "On" >
    //  < error statusCode="404" redirect="/ErrorPage/Page404/"/>
    //</customErrors>

        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["writerMail"];
            id = c.writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["writerMail"];
            var writerIdInfo = c.writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var headingValue = hm.GetListByWriter(writerIdInfo);

            return View(headingValue);          
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.categoryName,
                                                      Value = x.categoryId.ToString()
                                                  }).ToList();
            ViewBag.vlC = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writerMailInfo = (string)Session["writerMail"];
            var writerIdInfo = c.writers.Where(x => x.writerMail == writerMailInfo).Select(y => y.writerId).FirstOrDefault();
            p.headingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.writerId = writerIdInfo;
            p.headingStatus = true;
            hm.HeadingAdd(p);  
            return RedirectToAction("MyHeading");
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
            //p.headingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.headingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p =1)
        {

            var headings = hm.GetList().ToPagedList(p,5);
            return View(headings);
        }
    }
}