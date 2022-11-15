using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement_Project.Models
{
    public class UserDTO
    {
        public UserDTO()
        {
            UserId = Guid.Empty;
            FirstName = "Not Available";
            LastName = "Not Available";
            DateOfBirth = DateTime.Now;
            Gender = "Not Available";
            Street = "Not Available";
            City = "Not Available";
            Province = "Not Available";
            Country = "Not Available";
            PostalCode = "Not Available";

        }

        public UserDTO(Guid userid, string firstname, string lastname, DateTime dateofbirth, string gender, string street, string city, string province, string country, string postalcode)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Gender = gender;
            Street = street;
            City = city;
            Province = province;
            Country = country;
            PostalCode = postalcode;
        }

        public Guid UserId { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "DateFormat")]
        public DateTime DateOfBirth { get; set; }

        // date formate property created like "Jan 01, 2022"
        //[Display(ResourceType = typeof(Resources.Locale), Name = "DateFormat")]
        //public string DateFormat
        //{
        //    get
        //    {
        //        return DateOfBirth.ToString("MMM dd, yyyy");
        //    }
        //    set
        //    {
        //        DateFormat = value;
        //    }
        //}

        [Display(ResourceType = typeof(Resources.Locale), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "Street")]
        public string Street { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "City")]
        public string City { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "Province")]
        public string Province { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "Country")]
        public string Country { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "PostalCode")]
        public string PostalCode { get; set; }
    }

}