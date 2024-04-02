using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(TblMessages message)
        {
            db.TblMessages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateMessage(TblMessages message)
        {
            var value = db.TblMessages.Find(message.MessageId);
            value.MessageId = message.MessageId;
            value.Name = message.Name;
            value.Email = message.Email;
            value.Subject = message.Subject;
            value.MessageContent = message.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}