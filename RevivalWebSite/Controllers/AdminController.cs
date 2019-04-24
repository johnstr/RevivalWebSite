using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RevivalWebSite.Models;
using RevivalWebSite.ViewModels;
using System.Collections.Generic;
using RevivalWebSite.HelperClasses;

namespace RevivalWebSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : DefaultController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
          
        private List<UserViewModel> GetUserList()
        {
            var userlist = new List<UserViewModel>();
            DBContext.Users.ToList().ForEach(u => {
                var userRole = UserManager.GetRoles(u.Id).SingleOrDefault();
                if (userRole != "admin")
                    userlist.Add(new UserViewModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        UserName = u.UserName,
                        FullName = u.FullName,
                        RoleName = userRole
                    });
            });
            return userlist;
        }

   
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {   
          return View(GetUserList());
        }

        public ActionResult UserList()
        {
            return PartialView(GetUserList());
        }


        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var user = DBContext.Users.Where(a => a.Id == id).SingleOrDefault();
            var model = new EditUserViewModel(DBContext) {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FullName = user.FullName,
                RoleName = UserManager.GetRoles(user.Id).SingleOrDefault(),
                RoleId = user.Roles.SingleOrDefault().RoleId
            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            var userNameExists = DBContext.Users.Where(u => u.UserName == model.UserName && u.Id != model.Id).SingleOrDefault() != null ? true : false;
            if (!userNameExists)
            {
                var user = UserManager.FindById(model.Id);
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FullName = model.FullName;
                user.Roles.Clear();
                DBContext.SaveChanges();
                UserManager.AddToRole(user.Id, DBContext.Roles.Where(r => r.Id == model.RoleId).SingleOrDefault().Name);
                return Json(new { redirectTo = Url.Action("UserList", "Admin") });
            }
            ModelState.AddModelError("UserName", "Username already exists");
            return PartialView(model);
        }

        public ActionResult DeleteUser(string id)
        {
            var user = DBContext.Users.Where(u => u.Id == id).SingleOrDefault();
            if (user != null)
            {
                DBContext.Users.Remove(user);
                DBContext.SaveChanges();
            }
            return RedirectToAction("UserList");
        }

        public ActionResult Events()
        {
           var eventList = DBContext.Events.ToList();
           return View(eventList);
        }

        [HttpGet]
        public ActionResult CreateOrEditEvent(int? id)
        {
           if(id != null)
            { 
                var evnt = DBContext.Events.Where(e => e.ID == id).SingleOrDefault();
                var model = new EventViewModel()
                {
                    Id = evnt.ID,
                    Name = evnt.Name,
                    Name_ENG = evnt.Name_ENG,
                    Location = evnt.Location,
                    Location_ENG = evnt.Location_ENG,
                    About = evnt.About,
                    About_ENG = evnt.About_ENG,
                    StartTime = evnt.StartTime,
                    EndTime = evnt.EndTime,
                    PhotoURL = evnt.PhotoURL
                };
                return PartialView(model);
            }
            return PartialView(new EventViewModel());
        }


        [HttpPost]
        public ActionResult CreateOrEditEvent(EventViewModel model)
        {
            if (model.Id != 0)
            {
                var evnt = DBContext.Events.Where(e => e.ID == model.Id).SingleOrDefault();
                evnt.Name = model.Name;
                evnt.Name_ENG = model.Name_ENG;
                evnt.Location = model.Location;
                evnt.Location_ENG = model.Location_ENG;
                evnt.About = model.About;
                evnt.About_ENG = model.About_ENG;
                evnt.StartTime = model.StartTime;
                evnt.EndTime = model.EndTime;
                evnt.PhotoURL = model.PhotoURL;
            }
            else
            {
                DBContext.Events.Add(new Event
                {
                    Name = model.Name,
                    Name_ENG = model.Name_ENG,
                    Location = model.Location,
                    Location_ENG = model.Location_ENG,
                    About = model.About,
                    About_ENG = model.About_ENG,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    PhotoURL = model.PhotoURL
                });
            }
            DBContext.SaveChanges();
            return PartialView("EventList", DBContext.Events.ToList());
        }


        public ActionResult DeleteEvent(int id)
        {
           var evnt = DBContext.Events.Where(e => e.ID == id).SingleOrDefault();
            if(evnt != null)
            {
                MediaHelper.RemoveMedia(evnt.PhotoURL);
                DBContext.Events.Remove(evnt);
                DBContext.SaveChanges();
            }
           return PartialView("EventList", DBContext.Events.ToList());
        }

        public ActionResult SearchEvent(string search)
        {
            var eventList = DBContext.Events.Where(e => e.Name.Contains(search) || e.Name_ENG.Contains(search)).ToList();
            return PartialView("EventList", eventList);
        }

        [HttpPost]
        public JsonResult UploadFiles(HttpPostedFileBase file)
        {
            return Json(new { mediaURL = MediaHelper.SaveMedia(file) });
        }

        [HttpGet]
        public void RemoveFiles(string url)
        {
            MediaHelper.RemoveMedia(url);
        }

        public ActionResult Media()
        {
            var mediaList = DBContext.Media.ToList();
            return View(mediaList);
        }

        [HttpGet]
        public ActionResult CreateOrEditMedia(int? id)
        {
            if (id != null)
            {
                var media = DBContext.Media.Where(m => m.ID == id).SingleOrDefault();
                var model = new MediaViewModel(DBContext.MediaCategory.ToList())
                {
                    Id = media.ID,
                    Name = media.Name,
                    VideoURL = media.VideoURL,
                    Description = media.Description,
                    CategoryID = media.CategoryID,
                };
                return PartialView(model);
            }
            return PartialView(new MediaViewModel(DBContext.MediaCategory.OrderByDescending(m => m.ID).ToList()));
        }

        //Ajax request for creating or deleting media
        [HttpPost]
        public ActionResult CreateOrEditMedia(MediaViewModel model)
        {
            if (model.Id != 0)
            {
                var media = DBContext.Media.Where(m => m.ID == model.Id).SingleOrDefault();
                media.Name = model.Name;
                media.Description = model.Description;
                media.PostDate = DateTime.Now;
                media.Category = DBContext.MediaCategory.Where(c => c.ID == model.CategoryID).SingleOrDefault();
                media.VideoURL = model.VideoURL;
            }
            else {
                DBContext.Media.Add(new Media
                {
                    Name = model.Name,
                    Description = model.Description,
                    VideoURL = model.VideoURL,
                    Category = DBContext.MediaCategory.Where(c => c.ID == model.CategoryID).SingleOrDefault()
                });
            }
            DBContext.SaveChanges();
            return PartialView("MediaList", DBContext.Media.ToList());
        }

        //Ajax Delete look Media.cshtml
        [HttpGet]
        public ActionResult DeleteMedia(int id)
        {
            var mediaElem = DBContext.Media.Where(m => m.ID == id).SingleOrDefault();
            if (mediaElem != null)
            {
                //Remove media file from the site storage
                MediaHelper.RemoveMedia(mediaElem.VideoURL);
                DBContext.Media.Remove(mediaElem);
                DBContext.SaveChanges();
            }
            return PartialView("MediaList", DBContext.Media.ToList());
        }

        [HttpGet]
        public ActionResult MediaCategories()
        {
            var mediaCategoryList = DBContext.MediaCategory.OrderByDescending(m => m.ID).ToList();
            return View(mediaCategoryList);
        }

        //Ajax edit create MediaCategory
        [HttpPost]
        public ActionResult CreateOrEditMediaCategory(MediaCategory category)
        {
            if (category.ID != 0) {
                var media = DBContext.MediaCategory.Where(m => m.ID == category.ID).SingleOrDefault();
                media.Name = category.Name;
                media.Name_ENG = category.Name_ENG;
            }
            else
            {
                DBContext.MediaCategory.Add(category);
            }
            DBContext.SaveChanges();
            var mediaCategoryList = DBContext.MediaCategory.OrderByDescending(m => m.ID).ToList();
            return PartialView("MediaCategoryList", mediaCategoryList);
        }

        //Ajax Delete Media Category
        public ActionResult DeleteMediaCategory(int id)
        {
            var media = DBContext.MediaCategory.Where(m => m.ID == id).SingleOrDefault();
            if (media != null && media.ID != 1)
            {
                var defaultMedia = DBContext.MediaCategory.Where(m => m.ID == 1).SingleOrDefault();
                media.MediaList.ToList().ForEach(m => defaultMedia.MediaList.Add(m));
                DBContext.MediaCategory.Remove(media);
            }
            DBContext.SaveChanges();
            var mediaCategoryList = DBContext.MediaCategory.OrderByDescending(m => m.ID).ToList();
            return PartialView("MediaCategoryList", mediaCategoryList);
        }

        //Ajax Refresh Media List after changes in MediaCategory
        public ActionResult MediaList()
        {
            var mediaList = DBContext.Media.ToList();
            return PartialView(DBContext.Media.ToList());
        }

        public ActionResult SearchMedia(string search)
        {
            var mediaList = DBContext.Media.Where(m => m.Name.Contains(search)).ToList();
            return PartialView("MediaList", mediaList);
        }

    }
}