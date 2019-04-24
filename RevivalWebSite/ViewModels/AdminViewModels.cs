using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RevivalWebSite.Models;
using System.Web.Mvc;
using RevivalWebSite.DAL;

namespace RevivalWebSite.ViewModels
{

    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
 
    }

    public class EditUserViewModel : UserViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        public EditUserViewModel()
        {
        }

        public EditUserViewModel(RevivalContext dbContext)
        {
            Roles = new List<RoleViewModel>();
            dbContext.Roles.ToList().ForEach(r => Roles.Add(new RoleViewModel { Id = r.Id, Name = r.Name }));
        }

    }

    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Title English")]
        public string Name_ENG { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Location English")]
        public string Location_ENG { get; set; }
        [Required]
        [Display(Name = "About")]
        public string About { get; set; }
        [Required]
        [Display(Name = "About English")]
        public string About_ENG { get; set; }
        [Required]
        [Display(Name = "PhotoURL")]
        public string PhotoURL { get; set; }
    }

    public class MediaCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class MediaViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime PostDate { get; set; }
        [Required]
        [Display(Name = "Video URL")]
        public string VideoURL { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public virtual List<MediaCategoryViewModel> Categories { get; set; }

        public MediaViewModel() { }

        public MediaViewModel(List<MediaCategory> categories)
        {
            Categories = new List<MediaCategoryViewModel>();
            categories.ForEach(c => Categories.Add(new MediaCategoryViewModel
            {
                Id = c.ID,
                Name = c.Name + " / " + c.Name_ENG
            }));
            Categories.OrderByDescending(c => c.Id);
        }
    }

    
}