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

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "LastName")]
        public string LastName { get; set; }

        //[Display(ResourceType = typeof(Resources.Locale), Name = "DateFormat")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(ResourceType = typeof(Resources.Locale), Name = "DateFormat")]
        // date formate property created like "Jan 01, 2022"
        public string DateFormat
        {
            get
            {
                return DateOfBirth.ToString("MMM dd, yyyy");
            }
            set
            {
                DateFormat = value;
            }
        }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "Street")]
        public string Street { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "Province")]
        public string Province { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Locale), Name = "Country")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][0-9][A-Z]\s?[0-9][A-Z][0-9]$", ErrorMessage = "Invalid Postal Code Ex: X0X 0X0 (OR) X0X0X0")]
        [Display(ResourceType = typeof(Resources.Locale), Name = "PostalCode")]
        public string PostalCode { get; set; }
    }

}