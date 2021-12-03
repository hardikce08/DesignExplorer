using System.Web.Mvc;

namespace DesignExplorer.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              name: "Admin_Login",
              url: "Admin/Login",
              defaults: new { action = "Login", controller = "Account", areaname = AreaName, id = UrlParameter.Optional }
          );
            context.MapRoute(
              "Admin_Users",
              "Admin/Users",
              new { action = "List", controller = "User", areaname = AreaName, id = UrlParameter.Optional }
          );
            context.MapRoute(
              "Admin_UsersEdit",
              "Admin/Users/{id}",
              new { action = "EditUser", controller = "User", areaname = AreaName, id = UrlParameter.Optional }
          );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                  new[] { "DesignExplorer.Web.Areas.Admin.Controllers" }
            );


        }
    }
}