using DesignExplorer.DataAccess.Model;
using DesignExplorer.DataAccess;
using DesignExplorer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignExplorer
{
    public static class ProfileHelper
    {
        /// <summary>
        /// Presently logged in profile
        /// </summary>
        public static SessionProfile Profile
        {
            get
            {
                SessionProfile profile = null;
                if (HttpContext.Current == null && HttpContext.Current.Request.Cookies["UserId"] == null)
                {
                    return profile;
                }
                else if (HttpContext.Current.Request.Cookies["UserId"] != null)
                {
                    profile = new SessionProfile();
                    profile.UserId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                    profile.Email = HttpContext.Current.Request.Cookies["UserEmail"].Value;
                    profile.Token = HttpContext.Current.Request.Cookies["UserToken"].Value;
                    profile.Username = HttpContext.Current.Request.Cookies["UserName"].Value;
                }
                return profile;
            }
        }
    }
    public class SessionProfile
    {
        public SessionProfile()
        {

        }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public bool IsAdministrator { get; set; }

        //CacheRegionEnum _region;
        public CacheRegionEnum CacheRegion { get; set; }


    }
}