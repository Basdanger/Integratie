using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class ThemeController : TeslaBaseController
    {
        ThemeManager themeManager = new ThemeManager();
        GraphManager manager = new GraphManager();
        // GET: Theme
        public ActionResult Index()
        {
            IEnumerable<Theme> themas = themeManager.GetThemas();
            foreach(Theme t in themas)
            {
                t.TrendIndex = manager.GetFilledSingleTrendGraph(new Domain.Entities.Graph.Graph { PeriodSort = Domain.Entities.Graph.PeriodSort.Flex, PeriodLength = 5, ThemeFilter = t.Name }).TrendValue;

            }
            return View(themas);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult EditThemes()
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

        public ActionResult Theme(int id)
        {
            Theme thema = themeManager.GetThemeById(id);
            thema.TrendIndex = manager.GetFilledSingleTrendGraph(new Domain.Entities.Graph.Graph { PeriodSort = Domain.Entities.Graph.PeriodSort.Flex, PeriodLength = 5, ThemeFilter = thema.Name }).TrendValue;
            return View(thema);
        }

        public ActionResult CreateStory(int themaId)
        {
            ViewBag.themaId = themaId;

            return View();
        }

        [HttpPost]
        public ActionResult CreateStory(Story story, int themaId)
        {
            themeManager.AddStory(story, themaId);

            return RedirectToAction("Theme", new { id = themaId });
        }

        public ActionResult EditStories(int themaId)
        {

            List<Story> stories = themeManager.GetStories(themaId);
            ViewBag.Name = themeManager.GetThemeById(themaId).Name;
            ViewBag.themaId = themaId;
            return View(stories.AsEnumerable());
        }

        public ActionResult DeleteStory(int storyId,int themaId)
        {
            themeManager.DeleteStory(storyId);
            return RedirectToAction("EditStories",themaId);
        }

        public ActionResult Delete(int themaId)
        {
            themeManager.DeleteTheme(themaId);
            return RedirectToAction("EditThemes");
        }
    }
}
