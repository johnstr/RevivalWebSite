using RevivalWebSite.DAL;
using RevivalWebSite.HelperClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RevivalWebSite.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            ViewBag.Events = DBContext.Events.GetUpcoming(3);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Title = "Upcoming Events"; 
            var model = DBContext.Events.GetUpcoming();
            return View(model);
        }

        public ActionResult EventsByMonth(int month)
        {
            ViewBag.Title = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            var model = DBContext.Events.GetByMonth(month);
           return View("Events", model);
        }

        public ActionResult SearchEvents(string search)
        {
            ViewBag.Title = "Search Events";
            var model = DBContext.Events.SearchByName(search);
            return View("Events", model);
        }

        public ActionResult Media()
        {
            ViewBag.Title = "Media";
            var model = DBContext.Media.GetAll();
            ViewBag.Categories = DBContext.MediaCategory.ToCustomList();
            return View(model);
        }

        public ActionResult MediaRecent()
        {
            ViewBag.Title = "Recent Media";
            var model = DBContext.Media.GetRecent();
            ViewBag.Categories = DBContext.MediaCategory.ToCustomList();
            return View("Media", model);
        }

        public ActionResult MediaByCategory(int id)
        {
            ViewBag.Title = DBContext.MediaCategory.Where(m => m.ID == id).SingleOrDefault().Name;
            var model = DBContext.Media.GetByCategory(id);
            ViewBag.Categories = DBContext.MediaCategory.ToCustomList();
            return View("Media", model);
        }

        public ActionResult SearchMedia(string search)
        {
            ViewBag.Title = "Search Media";
            var model = DBContext.Media.SearchByName(search);
            ViewBag.Categories = DBContext.MediaCategory.ToCustomList();
            return View("Media", model);
        }

        public ActionResult Ministries()
        {
            return View();
        }

        public ActionResult ChangeLanguage(string lang, string returnUri)
        {
            if(lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);

            return Redirect(returnUri);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}