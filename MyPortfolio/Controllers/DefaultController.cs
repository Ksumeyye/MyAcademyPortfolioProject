using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous] //Herkes erişebilir.Muaf tutuldu.
    public class DefaultController : Controller
    {
        // GET: Default
        // Veri Listeleme Yapmak İçin Entities ile db nesnesi üretilir.
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeature.ToList(); //Listeleme Yapılır.
            return PartialView(values); // Values partialviewin içerisine verilir.
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage() //PartialView içerisinde sadece form gelecek.
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessages messages) //Dönüş tipi post işlemi yapılacağı için ActionResult kullandık.İsim olarak aynı isimlenir (sendmessage),Tbl message tablosundan parametre değeri alınır.
        {
            db.TblMessages.Add(messages); //db nesnesi adı altında tbl messagedan gelen messages parametresi değerlerini ekle.
            db.SaveChanges(); // Değişiklikleri kaydet.
            return RedirectToAction("Index"); // Yine index içine geri al.Yeni indexi yenile.
        }
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x => x.Status == true).ToList(); // 4'ten fazla hizmet eklenmesin diye db'den satus ekledik vc'den şartlı koşullanma yaptık.
            return PartialView(values);
        }
        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProjectPartial()
        {
            var categories = db.TblCategories.ToList(); //var categories içerisine kategorilerimizi listeledik. Sonra viewBag içerisine aldık.
            ViewBag.categories = categories;
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultExperiencePartial()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTeamPartial()
        {
            var values = db.TblTeams.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultSocialMediaPartial()
        {
            var values = db.TblSocialMedias.ToList();
            return PartialView(values);
        }
    }
}