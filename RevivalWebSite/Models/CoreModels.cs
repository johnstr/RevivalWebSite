using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RevivalWebSite.Models
{

    public class NewsPhoto
    {
        [Key]
        public int ID { get; set; }
        public string PhotoURL { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }


    //News table
    public class News
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name_ENG { get; set; }
        public string About { get; set; }
        public string About_ENG { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;

        public virtual ICollection<NewsPhoto> Photos { get; set; }
    }

    //Change ID to Id
    public class Event
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string  Name { get; set; }
        [MaxLength(50)]
        public string Name_ENG { get; set; }
        public string About { get; set; }
        public string About_ENG { get; set; }
        public string PhotoURL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Location_ENG { get; set; }
    }


    public class Media
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;

        public int CategoryID { get; set; }
        public virtual MediaCategory Category { get; set; }
    }

    public class MediaCategory
    {
        public int ID { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Name_ENG { get; set; }

        public virtual ICollection<Media> MediaList { get; set; }
    }


}