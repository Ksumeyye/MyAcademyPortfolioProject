using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblAdmins.ToList();
            return View(values);
        }
        [AllowAnonymous] // Bazı action metodlarını yetkilendirme gereksiniminden muaf tutar.
        public ActionResult UpdateProfile(int id)
        {
            var profile = db.TblAdmins.Find(id);
            if(profile==null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }
        [HttpPost]
        public ActionResult UpdateProfile(TblAdmins updateProfile)
        {
            var existingProfile = db.TblAdmins.Find(updateProfile.AdminId);
            if(existingProfile==null)
            {
                return HttpNotFound();
            }
            existingProfile.UserName = updateProfile.UserName;
            existingProfile.Password = updateProfile.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}