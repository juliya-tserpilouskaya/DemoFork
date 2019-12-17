using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.User
{
    public class LoginView
    {
        [Required(ErrorMessage = "Reguired")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Reguired")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}