using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string p = (string)Session["writerMail"];           
            var messageList = mm.GetListInBox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["writerMail"];
            var messageList = mm.GetListSendBox(p);
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var Value = mm.GetById(id);
            return View(Value);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Value = mm.GetById(id);
            return View(Value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["writerMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                
                p.senderMail = sender;
                p.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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
    }
}