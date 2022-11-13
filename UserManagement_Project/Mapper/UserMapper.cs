using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UMP_DataObject;
using UserManagement_Project.Models;

namespace UserManagement_Project.Mapper
{
    public static class UserMapper
    {
        public static UserDTO Map(this UserEntity userEntity )
        {
            return new UserDTO
            {
                UserId= userEntity.UserId,
                FirstName= userEntity.FirstName,
                LastName= userEntity.LastName,
                DateOfBirth= userEntity.DateOfBirth,
                Gender= userEntity.Gender,
                Street= userEntity.Street,
                City= userEntity.City,
                Province= userEntity.Province,
                Country = userEntity.Country,
                PostalCode = userEntity.PostalCode
            };
        }
    }
}