using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using DesignExplorer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DesignExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public ActionResult Login(string ReturnUrl)
        {
            //if (!CheckAuthorization.CheckExistingUserLogin())
            //{
            var userinfo = new User();
            try
            {
                // We do not want to use any existing identity information  
                EnsureLoggedOut();

                // Store the originating URL so we can attach it to a form field  
                userinfo.ReturnUrl = ReturnUrl;

                return View(userinfo);
            }
            catch
            {
                throw;
            }
            //}
            //else {
            //    return RedirectToLocal("~/BulkUpload/Index");
            //}
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(User entity, string ReturnUrl)
        {

            try
            {

                // Ensure we have a valid viewModel to work with  
                if (ModelState.IsValid)
                {
                    UserService us = new UserService();
                    var userInfo = us.CheckLoginUser(entity.EmailAddress.Trim(), UserService.Encryptdata(entity.Password));
                    if (userInfo != null)
                    {
                        //Login Success  
                        //For Set Authentication in Cookie (Remeber ME Option)  
                        SignInRemember(entity.EmailAddress, entity.RememberSignIn);

                        //Set A Unique ID in session  
                        Session["UserID"] = userInfo.UserID;

                        // If we got this far, something failed, redisplay form  
                        // return RedirectToAction("", "Dashboard");  
                        return RedirectToLocal(entity.ReturnUrl);
                    }
                    else
                    {
                        //Login Fail  
                        TempData["Error"] = "Either UserName or Password is Wrong";
                        return View(entity);
                    }
                }
                return View(entity);
            }
            catch
            {
                throw;
            }

        }
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action  
            if (Request.IsAuthenticated && Session["UserID"] != null)
            {
                Logout();
            }
        }
        //POST: Logout  
        //[HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always  
                //required NameSpace: using System.Web.Security;  
                //FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication  
                //required NameSpace: using System.Security.Principal;  
                //HttpContext.User = new GenericPrincipal(new GenericIdentity("User"), null);

                Session["UserID"] = null;
                System.Web.HttpContext.Current.Session.Remove("UserID");

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place  
                // this clears the Request.IsAuthenticated flag since this triggers a new request  
                return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }

        private void SignInRemember(string userName, bool isPersistent = false)
        {
            // Clear any lingering authencation data  
            //FormsAuthentication.SignOut();
            // Write the authentication cookie 
            string key = string.Format(CacheKeys.SesssionProfile, userName);
            FormsAuthentication.SetAuthCookie(key, isPersistent);
            //CacheHelper.Remove(string.Format(CacheKeys.SesssionProfile, userName), CacheRegionEnum.Security);
        }
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site  
                // so we will redirect to this "action"  
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                {
                    return Redirect(returnURL);
                }
                // If we cannot verify if the url is local to our host we redirect to a default location  
                return RedirectToAction("Index", "Configuration");
            }
            catch
            {
                throw;
            }
        }
    }
}