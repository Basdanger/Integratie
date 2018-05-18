using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class ThemeController : Controller
    {
        ThemeManager themeManager = new ThemeManager();
        // GET: Theme
        public ActionResult Index()
        {
            IEnumerable<Theme> themas = themeManager.GetThemas();
            return View(themas);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult ThemeConfig()
        {
            IEnumerable<Theme> themas = themeManager.GetThemas();
            return View(themas);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Theme thema, HttpPostedFileBase file)
        {
            thema.Image = new byte[file.ContentLength];
            file.InputStream.Read(thema.Image, 0, file.ContentLength);
            themeManager.AddTheme(thema);
            return RedirectToAction("Index");
        }

        public ActionResult Theme(int id) {
            Theme thema=themeManager.GetThemeById(id);

            return View(thema);
        }

        public ActionResult CreateStory(int themaId) {
            ViewBag.themaId = themaId;

            return View();
        }

        [HttpPost]
        public ActionResult CreateStory(Story story, int themaId)
        {
            themeManager.AddStory(story, themaId);

            return RedirectToAction("Theme",new { id = themaId });
        }

        public ActionResult EditStories(int themaId) {
            List<Story> stories=themeManager.GetStories(themaId);
            ViewBag.Name = themeManager.GetThemeById(themaId).Name;
            return View(stories.AsEnumerable());
        }

        public ActionResult DeleteStory(int storyId) {
            themeManager.DeleteStory(storyId);
            return RedirectToAction("EditStories");
        }
    }
}
