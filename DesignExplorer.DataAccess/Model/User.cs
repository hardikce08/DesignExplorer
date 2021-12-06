using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignExplorer.DataAccess.Model
{
    //public class User
    //{
    //    public int UserID { get; set; }
    //    [Required(ErrorMessage = "UserName is Required")]
    //    public string EmailAddress { get; set; }
    //    [Required(ErrorMessage = "Password is Required")]
    //    public string Password { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public string ContactNumber { get; set; }

    //    public string ImageName { get; set; }

    //    public int CompanyId { get; set; }
    //    public string ReturnUrl { get; set; }
    //    public bool RememberSignIn { get; set; }
        
    //}
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Permissions
    {
        public int debugger { get; set; }
        public int userManagement { get; set; }
        public int modelIntegration { get; set; }
        public int ontologyIntegration { get; set; }
        public int experimentExecution { get; set; }
        public int optimizationExecution { get; set; }
        public int metadataEdition { get; set; }
        public int resourceSharing { get; set; }
        public int userVisibility { get; set; }
        public int scopeVisibility { get; set; }
        public int modelVisibility { get; set; }
    }

    public class Feature
    {
        public int roleId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string observations { get; set; }
        public int access { get; set; }
    }

    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string observations { get; set; }
        public List<Feature> features { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public object image { get; set; }
        public bool active { get; set; }
        public Permissions permissions { get; set; }
        public Role role { get; set; }
        public int id { get; set; }
    }

    public class UserLoginApiResponse
    {
        public User user { get; set; }
        public string token { get; set; }
    }
    public class UserProfileEditModel
    {
        public int UserID { get; set; }

        public string EmailAddress { get; set; }



        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }



        [Required(ErrorMessage = "Old Password is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is Required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Re-Type Password is Required")]
        [Compare("NewPassword", ErrorMessage = "The New Password and Re-Type Password fields do not match.")]
        public string ReTypePassword { get; set; }
    }
}
