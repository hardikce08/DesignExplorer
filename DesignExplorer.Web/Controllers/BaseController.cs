using DesignExplorer.Web.Models;
using System.Web.Mvc;

namespace DesignExplorer.Web.Controllers
{
    //[CheckAuthorization]
    public abstract class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
        }
        private string _bearertoken;
        public string BearerToken
        {
            get
            {
                if (_bearertoken == null)
                {
                    _bearertoken = System.Configuration.ConfigurationManager.AppSettings["BearerToken"].ToString();
                }

                return _bearertoken;
            }
        }
        private string _apidomin;
        public string ApiDomain
        {
            get
            {
                if (_apidomin == null)
                {
                    _apidomin = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
                }

                return _apidomin;
            }
        }
        private SessionProfile _currentProfile;
        public SessionProfile CurrentProfile
        {
            get
            {
                if (_currentProfile == null)
                {
                    _currentProfile = ProfileHelper.Profile;
                    if (_currentProfile == null)
                    {
                        RedirectToAction("Login", "Home");
                    }
                }
                return _currentProfile;
            }
        }
    }
}