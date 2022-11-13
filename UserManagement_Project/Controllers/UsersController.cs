using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UMP_DataAccess;
using UMP_DataObject;
using UserManagement_Project.Mapper;
using UserManagement_Project.Models;

namespace UserManagement_Project.Controllers
{
    public class UsersController : Controller
    public class UsersController : SharedController
    {
        // GET: Users
        public ActionResult Index()
        {
            UserRepository userData = new UserRepository();
            List<UserDTO> userDTOs = new List<UserDTO>();
            try
            {
                var entityData = userData.GetUsers();
                foreach(var item in entityData)
                {
                    userDTOs.Add(item?.Map());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(userDTOs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Insert(UserDTO userDto)
        {
            UserRepository userdata = new UserRepository();
            try
            {
                UserEntity userEntity = new UserEntity()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    DateOfBirth = userDto.DateOfBirth,
                    Gender = userDto.Gender,
                    Street = userDto.Street,
                    City = userDto.City,
                    Province = userDto.Province,
                    Country = userDto.Country,
                    PostalCode = userDto.PostalCode
                };

                userdata.InsertNewUser(userEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}