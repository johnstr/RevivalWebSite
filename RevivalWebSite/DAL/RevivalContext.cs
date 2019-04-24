using Microsoft.AspNet.Identity.EntityFramework;
using RevivalWebSite.Models;
using RevivalWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RevivalWebSite.DAL
{
    public class RevivalContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaCategory> MediaCategory { get; set; }

        public RevivalContext()
            : base("name=RevivalConnection", throwIfV1Schema: false)
        {
           
        }

        //public string GetAdminRoleId()
        //{
        //   return Roles.Where(r => r.Name == "admin").SingleOrDefault().Id;
        //}

        //public async Task EditAccountInfoAsync(string userId, EditAccountInfoViewModel editUser)
        //{
        //    var user = Users.Where(u => u.Id == userId).SingleOrDefault();
        //    user.Email = editUser.Email;
        //    user.FullName = editUser.FullName;
        //    user.UserName = editUser.UserName;
        //    await SaveChangesAsync();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static RevivalContext Create()
        {
            return new RevivalContext();
        }
    }
}