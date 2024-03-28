using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeatures.ToList();

            return PartialView(values);
        }


        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();

            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjectPartial()
        {
            var categories = db.TblCategories.ToList();
            ViewBag.categories= categories;

            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}