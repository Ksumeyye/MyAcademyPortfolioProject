using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialmedias)
        {
            db.TblSocialMedias.Add(socialmedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var socialmedia = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(socialmedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialmedia)
        {
            var value = db.TblSocialMedias.Find(socialmedia.SocialMediaId);
            value.NameSurname = socialmedia.NameSurname;
            value.Gmail = socialmedia.Gmail;
            value.Linkedin = socialmedia.Linkedin;
            value.Github = socialmedia.Github;
            value.Twitter = socialmedia.Twitter;
            value.Instagram = socialmedia.Instagram;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}