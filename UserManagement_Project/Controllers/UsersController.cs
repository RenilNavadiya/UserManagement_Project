using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UMP_DataAccess;
using UserManagement_Project.Mapper;
using UserManagement_Project.Models;

namespace UserManagement_Project.Controllers
{
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

       
    }
}