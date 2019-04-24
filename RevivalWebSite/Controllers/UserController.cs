using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RevivalWebSite.ViewModels;

namespace RevivalWebSite.Controllers
{
    public class UserController : DefaultController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
      
    }
}