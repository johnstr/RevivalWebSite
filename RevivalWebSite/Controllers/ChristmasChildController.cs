using Microsoft.AspNet.Identity.Owin;
using RevivalWebSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevivalWebSite.Controllers
{
    public class ChristmasChildController : Controller
    {

      

        // GET: ChristmasChild
        public ActionResult Index()
        {

            return View();
        }
    }
}