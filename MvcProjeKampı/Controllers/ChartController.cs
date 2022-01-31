using MvcProjeKampı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                categoryName="yazılım",
                categoryCount =8
            });
            ct.Add(new CategoryClass()
            {
                categoryName ="seyahat",
                categoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                categoryName = "ticaret",
                categoryCount = 3
            });
            return ct;
        }
    }
}