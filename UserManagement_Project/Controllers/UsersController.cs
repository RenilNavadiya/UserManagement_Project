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
using UserManagement_Project.Resources;

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

        // this action is created by Maitri
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(UserDTO userDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {

                        userEntity = UserMapper.EnitityMap(userDTO);
                        userRepository.InsertNewUser(userEntity);
                        TempData["Message"] = userDTO.FirstName.ToUpper() + ": " + Locale.User_has_been_Saved_Successfully;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }

        }

        [HttpGet]
        public ActionResult UpdateUser(Guid userId)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            UserDTO userDTO = new UserDTO();
            try
            {
                GetAllUsers(userDTOs);
                userDTO = userDTOs.FirstOrDefault(x => x.UserId == userId);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View("UpdateUser", userDTO);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userEntity = UserMapper.EnitityMap(userDTO);
                    userRepository.UpdateUser(userEntity);
                    TempData["Message"] = userDTO.FirstName + ": " + Locale.User_has_been_edited_Successfully;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("UpdateUser", userDTO);
            }

        }

        public JsonResult DeleteUser(Guid userId)
        {
            string userName = "";
            try
            {
                var users = userRepository.GetUsers();
                userName = users.Where(x => x.UserId == userId).Select(x => x.FirstName).FirstOrDefault().ToString();
                var result = userRepository.DeleteUser(userId);
                return Json(userName.ToUpper()+ ": " + Locale.User_has_been_successfully_deleted);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Json("");
            }
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
                TempData["ErrorMessage"] = ex.Message;
            }
            return userDTOs;
        }
    }
}