using DesignExplorer.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignExplorer.Web.Areas.Admin.Controllers
{
    [CheckAuthorization]
    public abstract class BaseController : Controller
    {
        // GET: Admin/Base
        public BaseController()
        {
        }
        private SessionProfile _currentProfile;
        public SessionProfile CurrentProfile
        {
            get
            {
                if (_currentProfile == null)
                {
                    _currentProfile = ProfileHelper.AdminProfile;
                }

                return _currentProfile;
            }
        }
    }
}