﻿using DesignExplorer.DataAccess;
using DesignExplorer.DataAccess.Model;
using DesignExplorer.Helper;
using System.Web;

namespace DesignExplorer.Web.Areas.Admin
{
    public static class ProfileHelper
    {
        /// <summary>
        /// Presently logged in profile
        /// </summary>
        public static SessionProfile AdminProfile
        {
            get
            {
                if (HttpContext.Current == null || !HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }

                SessionProfile profile = null;
                //string key = string.Format(CacheKeys.SesssionAdminProfile, HttpContext.Current.User.Identity.Name);

                CacheHelper.Get<SessionProfile>(HttpContext.Current.User.Identity.Name.Replace("SessionProfile_", "SessionAdminProfile_"), out profile, CacheRegionEnum.Security);

                //var o = HttpContext.Current.Cache[HttpContext.Current.User.Identity.Name];

                if (profile == null)
                {
                    profile = new SessionProfile();
                    //var user = Membership.GetUser();
                    //Guid guid = Guid.Parse(user.ProviderUserKey.ToString());
                    UserService us = new UserService();
                    profile.LoggedUserProfile = us.UserProfileByUserId(HttpContext.Current.User.Identity.Name.Replace("SessionAdminProfile_", ""));
                    CacheHelper.Add<SessionProfile>(HttpContext.Current.User.Identity.Name, profile, CacheRegionEnum.Security, 10);
                    // add object in cache so we can resolve someone on the site is active
                    System.Diagnostics.Trace.WriteLine("Admin profile added to cache");

                }
                //CacheHelper.Get<SessionProfile>(key, out o, CacheRegionEnum.Security);
                return profile;
                //return (SessionProfile)HttpContext.Current.Cache[HttpContext.Current.User.Identity.Name];
            }
        }
    }
    public class SessionProfile
    {
        public SessionProfile()
        {

        }
        public User LoggedUserProfile { get; set; }


        public bool IsAdministrator { get; set; }

        //CacheRegionEnum _region;
        public CacheRegionEnum CacheRegion { get; set; }


    }
}