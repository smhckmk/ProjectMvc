using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValue = cm.GetList();
            return View(contactValue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetById(id);
            return View(contactValue);
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}