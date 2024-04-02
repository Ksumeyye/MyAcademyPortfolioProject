using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values);
        }
        public ActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeam(TblTeams teams)
        {
            db.TblTeams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTeam(int id)
        {
            var team = db.TblTeams.Find(id);
            db.TblTeams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeam(TblTeams team)
        {
            var value = db.TblTeams.Find(team.TeamId);
            value.ImageUrl = team.ImageUrl;
            value.NameSurname = team.NameSurname;
            value.Title = team.Title;
            value.Description = team.Description;
            value.TwitterUrl = team.TwitterUrl;
            value.LinkedinUrl = team.LinkedinUrl;
            value.InstagramUrl = team.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}