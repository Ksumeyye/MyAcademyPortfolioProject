using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature feature)
        {
            db.TblFeature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature feature)
        {
            var value = db.TblFeature.Find(feature.FeatureId);
            value.FeatureId = feature.FeatureId;
            value.ImageUrl = feature.ImageUrl;
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}