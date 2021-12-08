using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using DesignExplorer.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DesignExplorer.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]

        public ActionResult Login()
        {
            var userinfo = new User();
            try
            {
                // We do not want to use any existing identity information  
                return View(userinfo);
            }
            catch
            {
                throw;
            }
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
                    UserRequest user = new UserRequest();
                    user.Username = "Test";
                    user.Password = "Test754";
                    var postString = JsonConvert.SerializeObject(user);
                    //var objResponse = WebHelper.GetWebAPIResponseWithErrorDetails(APIURL, WebHelper.ContentType.application_json, WebRequestMethods.Http.Post, postString, "Authorization:Bearer " + token, "", "");
                    var objResponse = WebHelper.GetWebAPIResponseWithErrorDetails(ApiDomain + "/authenticate", WebHelper.ContentType.application_json, WebRequestMethods.Http.Post, postString, "", "", "");
                    var res = JsonConvert.DeserializeObject<UserLoginApiResponse>(objResponse.ResponseString);

                    if (res != null)
                    {
                        //Set A Unique ID in session  
                        HttpCookie c = new HttpCookie("UserId");
                        c.Expires = DateTime.Now.AddDays(1);
                        c.Value = res.user.id.ToString();
                        Response.Cookies.Add(c);

                        var UserEmail = new HttpCookie("UserEmail");
                        UserEmail.Expires = DateTime.Now.AddDays(1);
                        UserEmail.Value = res.user.email.ToString();
                        HttpContext.Response.Cookies.Add(UserEmail);
                        var UserToken = new HttpCookie("UserToken");
                        UserToken.Expires = DateTime.Now.AddDays(1);
                        UserToken.Value = res.token.ToString();
                        HttpContext.Response.Cookies.Add(UserToken);
                        HttpCookie Username = new HttpCookie("UserName");
                        Username.Expires = DateTime.Now.AddDays(1);
                        Username.Value = res.user.userName.ToString();
                        Response.Cookies.Add(Username);
                        return RedirectToLocal("");
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
                Session.Abandon();
                Session.Clear();
                Response.Cookies.Clear();
                HttpCookie myCookie = Request.Cookies["UserId"];
                if (myCookie != null)
                {
                    myCookie.Expires = DateTime.Now;
                    Response.Cookies.Add(myCookie);
                }
               
                HttpCookie UsernameCookie = Request.Cookies["UserEmail"];
                if (UsernameCookie != null)
                {
                    UsernameCookie.Expires = DateTime.Now;
                    Response.Cookies.Add(UsernameCookie);
                }
                HttpCookie UserRoleCookie = Request.Cookies["UserToken"];
                if (UserRoleCookie != null)
                {
                    UserRoleCookie.Expires = DateTime.Now;
                    Response.Cookies.Add(UserRoleCookie);
                }
                HttpCookie UserName = Request.Cookies["UserName"];
                if (UserName != null)
                {
                    UserName.Expires = DateTime.Now;
                    Response.Cookies.Add(UserName);
                }
                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place  
                // this clears the Request.IsAuthenticated flag since this triggers a new request  
                return RedirectToAction("Login", "Home");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Dashboard()
        {
            try
            {
                return View();
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
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                throw;
            }
        }
    }
}