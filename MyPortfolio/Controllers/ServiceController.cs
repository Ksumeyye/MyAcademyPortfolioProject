using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices service)
        {
            db.TblServices.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblServices.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblServices services)
        {
            var value = db.TblServices.Find(services.ServiceId);
            value.ServiceId = services.ServiceId;
            value.Icon = services.Icon;
            value.Title = services.Title;
            value.Description = services.Description;
            value.Status = services.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id)
        {
            var value = db.TblServices.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            var value = db.TblServices.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //public ActionResult ChangeStatus(int id)
        //{
            //var value = db.TblServices.Find(id);
            //if(value.Status==true)
            //{
                //value.Status = false;
            //}
            //else
            //{
                //value.Status = true;
            //}
            //db.SaveChanges();
            //return RedirectToAction("Index");
            
        }
    }
