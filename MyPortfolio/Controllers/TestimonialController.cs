using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials testimonial)
        {
            db.TblTestimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonial)
        {
            var value = db.TblTestimonials.Find(testimonial.TestimonialId);
            value.ImageUrl = testimonial.ImageUrl;
            value.NameSurname = testimonial.NameSurname;
            value.Comment = testimonial.Comment;
            value.Title = testimonial.Title;
            value.Status = testimonial.Status;
            value.CommentDate = testimonial.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}