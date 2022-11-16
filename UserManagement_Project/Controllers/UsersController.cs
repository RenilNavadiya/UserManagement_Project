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
            return View("Create");
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteUser(Guid userId)
        {
            UserRepository userRepository = new UserRepository();
            
            try
            {
                var result = userRepository.DeleteUser(userId);
                               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return RedirectToAction("Index");
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