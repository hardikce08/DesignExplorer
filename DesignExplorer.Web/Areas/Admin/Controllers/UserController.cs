using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignExplorer.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User/List
        public ActionResult List()
        {
            UserService us = new UserService();
            var userInfo = us.AllUsers;
            return View(userInfo);
        }
        public ActionResult EditUser(int Id)
        {

            UserService us = new UserService();
            var userInfo = us.UserProfileByUserId(Id);
            return View(userInfo);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {

            UserService us = new UserService();
            us.User_InsertOrUpdate(user);
            if (user.UserID == 0)
            {
                TempData["Message"] = "User Added Successfully";
            }
            else
            {
                TempData["Message"] = "User Updated Successfully";
            }
            return Redirect("~/Admin/Users");
        }
    }
}