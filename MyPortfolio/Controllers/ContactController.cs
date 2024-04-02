using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContacts contact)
        {
            db.TblContacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContacts contact)
        {
            var value = db.TblContacts.Find(contact.ContactId);
            value.ContactId = contact.ContactId;
            value.NameSurname = contact.NameSurname;
            value.Address = contact.Address;
            value.Phone = contact.Phone;
            value.Email = contact.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}