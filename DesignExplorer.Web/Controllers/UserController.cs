using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignExplorer.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        //public ActionResult Update(int Id = 0)
        //{
        //    UserService us = new UserService();
        //    var model = us.UserProfileByUserId(Id);
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Update(User model)
        //{
        //    UserService us = new UserService();
        //    us.UpdateUserProfileData(model);
        //    model = us.UserProfileByUserId(model.UserID);
        //    TempData["Message"] = "Profile details has been updated";
        //    return View(model);
        //}
        //public ActionResult ChangePassword(int Id = 0)
        //{
        //    UserService us = new UserService();
        //    var model = us.UserProfileByUserId(Id);
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult ChangePassword(User model, FormCollection form)
        //{
        //    UserService us = new UserService();
        //    string Oldpass = form["OldPassword"]; ;
        //    bool IsValid = us.IsValidOldPassword(model.UserID, form["OldPassword"]);
        //    if (IsValid)
        //    {
        //        if (form["NewPassword"] == form["ConfirmPassword"])
        //        {
        //            us.UpdateNewPassword(model.UserID, form["ConfirmPassword"]);
        //            TempData["Message"] = "Password has been updated";
        //        }
        //        else
        //        {
        //            TempData["Error"] = "New Password and Confirm PAssword should be same";
        //        }
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Old Password is not valid";
        //    }
        //    model = us.UserProfileByUserId(model.UserID);
        //    return View(model);
        //}
    }
}