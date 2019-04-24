using RevivalWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RevivalWebSite.DAL
{
    public class RevivalDbInitializer : DropCreateDatabaseIfModelChanges<RevivalContext>
    {
        protected override void Seed(RevivalContext context)
        {
            //new List<Address> {
            //    new Address { City = "New York", StreetAdress = "1232 Zarichna" },
            //    new Address {City = "Atlanta", StreetAdress = "1234 Nicolus Street" },
            //    new Address {City = "New York", StreetAdress = "1211 Zarichna" },
            //    new Address {City = "Atlanta", StreetAdress = "1 Iphone Street" },
            //    new Address {City = "Chattanooga", StreetAdress = "14049 Scenic Hwy" },
            //    new Address {City = "Atlanta", StreetAdress = "1 Mehico Street" },
            //    new Address {City = "Chattanooga", StreetAdress = "34 Scenic Hwy" }
            //}.ForEach(address => context.Addresses.Add(address));

            //context.SaveChanges();

            //new List<Child>
            //{
            //    new Child { Name = "Vanya", Age = 21, Sex = true, FamilyID = 1},
            //    new Child { Name = "Luke", Age = 15, Sex = true, FamilyID = 1},
            //    new Child { Name = "Vanya", Age = 21, Sex = true, FamilyID = 2},
            //    new Child { Name = "Samy", Age = 11, Sex = false, FamilyID = 3},
            //    new Child { Name = "Nick", Age = 13, Sex = true, FamilyID = 3},
            //    new Child { Name = "Anna", Age = 11, Sex = false, FamilyID = 4},
            //    new Child { Name = "Emely", Age = 15, Sex = false, FamilyID = 5},
            //    new Child { Name = "Mary", Age = 12, Sex = false, FamilyID = 5}
            //}.ForEach(child => context.Children.Add(child));

            //context.SaveChanges();

            //new List<Parent>
            //{
            //    new Parent {Name = "Ivan Tymophiyovich", PhoneNumber = "096-8537-455" },
            //    new Parent {Name = "Bananchick", PhoneNumber = "096-8137-455" },
            //    new Parent {Name = "Ivan Mickhaylo", PhoneNumber = "096-8537-455" },
            //    new Parent {Name = "Ivan Prokopchuck", PhoneNumber = "026-8537-455" },
            //    new Parent {Name = "Natalia Ivanivna", PhoneNumber = "093-8537-455" },
            //    new Parent {Name = "Vera Petrovna", PhoneNumber = "094-8537-455" },
            //    new Parent {Name = "Bananchick Volodimirovich", PhoneNumber = "094-8111-453" }
            //}.ForEach(parent => context.Parents.Add(parent));

            //context.SaveChanges();

            //new List<Family>
            //{
            //    new Family { FName= "Korniychuck", AddressID = 1, ParentID = 1 },
            //    new Family { FName= "Tan", AddressID = 2, ParentID = 2 },
            //    new Family { FName= "Krisno", AddressID = 3, ParentID = 3 },
            //    new Family { FName= "Lanska", AddressID = 4, ParentID = 4 },
            //    new Family { FName= "Zelinskiy", AddressID = 5, ParentID = 5 },
            //    new Family { FName= "Tsvigaylo", AddressID = 6, ParentID = 6 },
            //    new Family { FName= "Marks", AddressID = 7, ParentID = 7 },
            //}.ForEach(family => context.Families.Add(family));

            //context.SaveChanges();

           // base.Seed(context);
        }
    }
}