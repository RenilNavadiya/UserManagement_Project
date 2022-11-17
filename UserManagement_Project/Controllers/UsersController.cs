using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using UMP_DataAccess;
using UMP_DataObject;
using UserManagement_Project.Mapper;
using UserManagement_Project.Models;

namespace UserManagement_Project.Controllers
{
    public class UsersController : SharedController
    {
        private UserRepository userRepository = new UserRepository();
        private UserEntity userEntity = new UserEntity();

        // GET: Users
        public ActionResult Index()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            GetAllUsers(userDTOs);
            return View(userDTOs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(UserDTO userDTO)
        {

            try
            {
                userEntity = UserMapper.EnitityMap(userDTO);
                userRepository.InsertNewUser(userEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            TempData["Message"] = "User with name: " + userDTO.FirstName + " has been Saved Successfully ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateUser(Guid userId)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            GetAllUsers(userDTOs);
            var user = userDTOs.FirstOrDefault(x => x.UserId == userId);

            return View("UpdateUser", user);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDTO userDTO)
        {

            UserRepository userRepository = new UserRepository();
            try
            {
                userEntity = UserMapper.EnitityMap(userDTO);
                userRepository.UpdateUser(userEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            TempData["Message"] = "User with name: " + userDTO.FirstName + " has been edited Successfully ";
            return RedirectToAction("Index");
        }

        public JsonResult DeleteUser(Guid userId)
        {
            UserRepository userRepository = new UserRepository();
            string userName = "";

            try
            {
                var users = userRepository.GetUsers();
                userName = users.Where(x => x.UserId == userId).Select(x => x.FirstName).FirstOrDefault().ToString();
                var result = userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return Json($"User with name: {userName} has been successfully deleted!");
        }

        //GetAllUsers private method to use it in a various places
        private List<UserDTO> GetAllUsers(List<UserDTO> userDTOs)
        {
            try
            {
                var entityData = userRepository.GetUsers();
                foreach (var item in entityData)
                {
                    userDTOs.Add(item?.Map());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return userDTOs;
        }
    }
}