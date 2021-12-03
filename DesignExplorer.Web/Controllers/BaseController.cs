using DesignExplorer.Web.Models;
using System.Web.Mvc;

namespace DesignExplorer.Web.Controllers
{
    [CheckAuthorization]
    public abstract class BaseController : Controller
    {
        // GET: Base
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
                    _currentProfile = ProfileHelper.Profile;
                }

                return _currentProfile;
            }
        }
    }
}