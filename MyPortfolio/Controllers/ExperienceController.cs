using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperiences experience)
        {
            db.TblExperiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences experience)
        {
            var value = db.TblExperiences.Find(experience.ExperienceId);
            value.ExperienceId = experience.ExperienceId;
            value.StartYear = experience.StartYear;
            value.EndYear = experience.EndYear;
            value.Title = experience.Title;
            value.Description = experience.Description;
            value.Company = experience.Company;
            value.Location = experience.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}