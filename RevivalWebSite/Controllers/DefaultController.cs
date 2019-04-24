using Microsoft.AspNet.Identity.Owin;
using RevivalWebSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevivalWebSite.Controllers
{
    public abstract class DefaultController : Controller
    {
        private RevivalContext _dbContext;

        public RevivalContext DBContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<RevivalContext>();

            }
            private set
            {
                _dbContext = value;
            }
        }
    }
}