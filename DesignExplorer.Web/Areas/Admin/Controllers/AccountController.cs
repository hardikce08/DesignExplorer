using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using DesignExplorer.Helper;
using System.Web.Mvc;
using System.Web.Security;

namespace DesignExplorer.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
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
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(User entity)
        {

            try
            {

                // Ensure we have a valid viewModel to work with  
                if (ModelState.IsValid)
                {
                    UserService us = new UserService();
                    var userInfo = us.CheckAdminLoginUser(entity.EmailAddress.Trim(), UserService.Encryptdata(entity.Password));
                    if (userInfo != null)
                    {
                        //Login Success  
                        //For Set Authentication in Cookie (Remeber ME Option)  
                        SignInRemember(entity.EmailAddress, true);

                        //Set A Unique ID in session  
                        Session["AdminUserID"] = userInfo.UserID;
                        //HttpContext.User = new GenericPrincipal(new GenericIdentity("AdminUser"), new string[] { "Admin" });
                        // If we got this far, something failed, redisplay form  
                        // return RedirectToAction("", "Dashboard");  
                        return RedirectToLocal(entity.ReturnUrl);
                    }
                    else
                    {
                        //Login Fail  
                        TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
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
            if (Request.IsAuthenticated && Session["AdminUserID"] != null)
                Logout();
        }
        //POST: Logout  
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always  
                //required NameSpace: using System.Web.Security;  
                //FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication  
                //required NameSpace: using System.Security.Principal;  
                //HttpContext.User = new GenericPrincipal(new GenericIdentity("AdminUser"), null);
                Session["AdminUserID"] = null;
                System.Web.HttpContext.Current.Session.Remove("AdminUserID");

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place  
                // this clears the Request.IsAuthenticated flag since this triggers a new request  
                return RedirectToLocal("~/Admin/Login");
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
            string key = string.Format(CacheKeys.SesssionAdminProfile, userName);

            FormsAuthentication.SetAuthCookie(key, isPersistent);
        }
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site  
                // so we will redirect to this "action"  
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);
                // If we cannot verify if the url is local to our host we redirect to a default location  
                //return RedirectToAction("Users",");
                return Redirect("~/Admin/Users");
            }
            catch
            {
                throw;
            }
        }
    }
}