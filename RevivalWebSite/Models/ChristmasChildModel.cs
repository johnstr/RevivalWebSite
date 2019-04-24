using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RevivalWebSite.Models
{
    
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(50)]
        public string StreetAdress { get; set; }
    }

    public class Parent
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string About { get; set; }


        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
         
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }

    public class PhoneNumber
    {
        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        [MaxLength(25)]
        public string Operator { get; set; }

        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }
    }

    public class Child
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }

        public int ParentID { get; set; }
        public virtual Parent Parent { get; set;}
    }

}