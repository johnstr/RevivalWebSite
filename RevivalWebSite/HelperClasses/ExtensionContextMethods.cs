using System;
using System.Collections.Generic;
using RevivalWebSite.DAL;
using System.Linq;
using System.Web;
using RevivalWebSite.Models;
using System.Data.Entity;

namespace RevivalWebSite.HelperClasses
{
    public static class ExtensionContextMethods
    {
        ///Extension methods for Events
        public static List<Event> GetUpcoming(this DbSet<Event> events)
        {
            return events.Where(e => e.EndTime > DateTime.Now).OrderBy(e => e.StartTime).ToList();
        }

        public static List<Event> GetUpcoming(this DbSet<Event> events, int num)
        {
            return events.Where(e => e.EndTime > DateTime.Now).OrderBy(e => e.StartTime).Take(num).ToList();
        }


        public static List<Event> GetNextFew(this DbSet<Event> events, int skip, int num)
        {
           
            return events.Where(e => e.EndTime > DateTime.Now).OrderBy(e => e.StartTime).Skip(skip).Take(num).ToList();
        }

        public static List<Event> GetByMonth(this DbSet<Event> events, int month)
        {
            return events.Where(e => e.EndTime > DateTime.Now && e.StartTime.Month == month).OrderBy(e => e.StartTime).ToList();
        }

        public static List<Event> SearchByName(this DbSet<Event> events, string name)
        {
            return events.Where(e => e.EndTime > DateTime.Now && (e.Name.Contains(name)|| e.Name_ENG.Contains(name))).ToList();
        }

        ///Extension methods for Media
        public static List<Media> GetAll(this DbSet<Media> media)
        {
            return media.ToList();
        }

        public static List<Media> GetRecent(this DbSet<Media> media)
        {
            return media.OrderByDescending(m => m.PostDate).ToList();
        }

        public static List<Media> GetByCategory(this DbSet<Media> media, int categoryId)
        {
            return media.Where(m => m.CategoryID == categoryId).ToList();
        }

        public static List<Media> SearchByName(this DbSet<Media> media, string name)
        {
            return media.Where(m => m.Name.Contains(name)).ToList();
        }

        ///Extension methods for MediaCategory
        public static List<MediaCategory> ToCustomList(this DbSet<MediaCategory> mediaCategory)
        {
            return mediaCategory.OrderByDescending(c => c.ID).ToList();
        }
    }
}