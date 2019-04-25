using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevivalWebSite.HelperClasses
{
    public class MediaHelper
    {
        public static string IMG_REPOSITORY_PATH = "/Resources/UploadedImg/";
        public static string VIDEO_REPOSITORY_PATH = "/Resources/UploadedVideo/";

        private static bool isImage(string contentType)
        {
            if (contentType.Contains("image"))
            {
                return true; 
            }
            return false;
        }

        //saves uploaded file to local repository on server and returns a relative link to that file
        public static string SaveMedia(HttpPostedFileBase file)
        {
            string relPath = "", path = "";
            var newFileName = DateTime.Now.ToString("yyyyMMddHHmm") + file.FileName.Replace(" ", "");
            if (isImage(file.ContentType))
            {
                path = HttpContext.Current.Server.MapPath("~" + IMG_REPOSITORY_PATH) + newFileName;
                relPath = IMG_REPOSITORY_PATH + newFileName;
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~" + VIDEO_REPOSITORY_PATH) + newFileName;
                relPath = VIDEO_REPOSITORY_PATH + newFileName;
            }
            file.SaveAs(path);
            return relPath;

        }

        public static void RemoveMedia(string removeFile)
        {
            var path = HttpContext.Current.Server.MapPath(removeFile);
            if (File.Exists(path))
                File.Delete(path);
        }

        //Formats youtube video link to embeded
        public static string FormatVideoLink(string link)
        {
            if(link.Contains("https://www.youtube.com/"))
            {
                return link.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/");
            }
            return link;
        }
       

    
    }
}