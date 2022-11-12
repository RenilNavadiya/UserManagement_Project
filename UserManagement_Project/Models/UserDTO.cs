using System;
using System.Collections.Generic;
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

         public UserDTO(Guid userid,string firstname,string lastname,DateTime dateofbirth,string gender,string street,string city,string province,string country,string postalcode)
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

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public string Country { get; set; }

    public string PostalCode { get; set; }
    }

}